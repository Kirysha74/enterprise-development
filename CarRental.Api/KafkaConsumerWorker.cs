using AutoMapper;
using CarRental.Application.Contracts.Dto;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace CarRental.Api;

/// <summary>
/// Kafka background consumer that reads messages and persists rentals
/// </summary>
public class KafkaConsumerWorker(
    ILogger<KafkaConsumerWorker> logger,
    IConsumer<Ignore, string> consumer,
    IServiceScopeFactory scopeFactory,
    IMapper mapper,
    IOptions<KafkaOptions> options) : BackgroundService
{
    private readonly KafkaOptions _options = options.Value;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("KafkaConsumerWorker started. Listening topic: {Topic}", _options.Topic);

        // Подписка с ретраями
        await SubscribeWithRetryAsync(stoppingToken);

        consumer.Subscribe(_options.Topic);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var consumeResult = consumer.Consume(stoppingToken);
                if (consumeResult?.Message?.Value == null)
                {
                    logger.LogWarning("Received empty Kafka message");
                    continue;
                }

                var dto = JsonSerializer.Deserialize<RentalEditDto>(consumeResult.Message.Value);
                if (dto == null)
                {
                    logger.LogWarning("Failed to deserialize message: {Value}", consumeResult.Message.Value);
                    consumer.Commit(consumeResult);
                    continue;
                }

                using var scope = scopeFactory.CreateScope();
                var rentalRepo = scope.ServiceProvider
                    .GetRequiredService<IRepository<Rental>>();
                var carRepo = scope.ServiceProvider
                    .GetRequiredService<IRepository<Car>>();
                var clientRepo = scope.ServiceProvider
                    .GetRequiredService<IRepository<Client>>();

                // Проверка существования автомобиля и клиента
                var car = await carRepo.GetByIdAsync(dto.CarId);
                if (car == null)
                {
                    logger.LogWarning("Car with Id {CarId} does not exist", dto.CarId);
                    consumer.Commit(consumeResult);
                    continue;
                }

                var client = await clientRepo.GetByIdAsync(dto.ClientId);
                if (client == null)
                {
                    logger.LogWarning("Client with Id {ClientId} does not exist", dto.ClientId);
                    consumer.Commit(consumeResult);
                    continue;
                }

                // Создание Rental из DTO
                var rental = mapper.Map<Rental>(dto);

                var addedRental = await rentalRepo.AddAsync(rental);
                logger.LogInformation("Saved Rental from Kafka: Id={Id}, CarId={CarId}, ClientId={ClientId}, Date={Date}, Hours={Hours}",
                    addedRental.Id,
                    addedRental.CarId,
                    addedRental.ClientId,
                    addedRental.RentalDate,
                    addedRental.RentalHours);

                consumer.Commit(consumeResult);
            }
            catch (ConsumeException cex)
            {
                logger.LogError(cex, "Kafka consume error");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected consumer error");
            }
        }
    }

    private async Task SubscribeWithRetryAsync(CancellationToken stoppingToken)
    {
        const int maxRetries = 5;
        for (int retry = 0; retry < maxRetries; retry++)
        {
            try
            {
                consumer.Subscribe(_options.Topic);
                logger.LogInformation("Successfully subscribed to Kafka topic: {Topic}", _options.Topic);
                return;
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Failed to subscribe to Kafka (attempt {Retry}/{MaxRetries})",
                    retry + 1, maxRetries);

                if (retry == maxRetries - 1)
                    throw;

                await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, retry)), stoppingToken);
            }
        }
    }
}