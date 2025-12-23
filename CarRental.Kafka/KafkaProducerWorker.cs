using Confluent.Kafka;
using CarRental.Application.Contracts.Dto;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace CarRental.Kafka;

/// <summary>
/// Periodically produces rental messages to Kafka
/// </summary>
public class KafkaProducerWorker(
    ILogger<KafkaProducerWorker> logger,
    ContractGenerator generator,
    IProducer<Null, string> producer,
    IOptions<KafkaOptions> options) : BackgroundService
{
    private readonly KafkaOptions _options = options.Value;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("KafkaProducerWorker started. Producing to topic {Topic} every {Delay} ms",
            _options.Topic, _options.ProduceDelayMs);

        // Добавляем ретраи при подключении к Kafka
        var retryCount = 0;
        const int maxRetries = 5;

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var rentalDto = generator.Generate();
                var message = new Message<Null, string>
                {
                    Value = JsonSerializer.Serialize(rentalDto)
                };

                var deliveryResult = await producer.ProduceAsync(_options.Topic, message, stoppingToken);
                logger.LogInformation("Produced rental to {TopicPartitionOffset}: CarId={CarId}, ClientId={ClientId}, Hours={Hours}",
                    deliveryResult.TopicPartitionOffset,
                    rentalDto.CarId,
                    rentalDto.ClientId,
                    rentalDto.RentalHours);

                retryCount = 0; // Сброс счетчика ретраев при успешной отправке
            }
            catch (ProduceException<Null, string> ex)
            {
                logger.LogError(ex, "Kafka produce error: {Reason}", ex.Error.Reason);

                if (retryCount < maxRetries)
                {
                    retryCount++;
                    var delay = TimeSpan.FromSeconds(Math.Pow(2, retryCount)); // Exponential backoff
                    logger.LogWarning("Retrying in {Delay} seconds (attempt {Retry}/{MaxRetries})",
                        delay.TotalSeconds, retryCount, maxRetries);
                    await Task.Delay(delay, stoppingToken);
                    continue;
                }
                else
                {
                    logger.LogError("Max retries reached. Stopping producer.");
                    break;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error producing message");
            }

            await Task.Delay(_options.ProduceDelayMs, stoppingToken);
        }
    }
}