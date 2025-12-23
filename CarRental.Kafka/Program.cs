using CarRental.Kafka;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

var builder = Host.CreateApplicationBuilder(args);

// Добавьте конфигурацию логгирования для отладки
builder.Logging.AddSimpleConsole(options =>
{
    options.IncludeScopes = true;
    options.SingleLine = true;
    options.TimestampFormat = "HH:mm:ss ";
});

builder.AddServiceDefaults();

builder.Services.AddOptions<KafkaOptions>()
    .Bind(builder.Configuration.GetSection("Kafka"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddHostedService<KafkaProducerWorker>();

// Producer с ретраями
builder.Services.AddSingleton<IProducer<Null, string>>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var kafkaOptions = sp.GetRequiredService<IOptions<KafkaOptions>>().Value;
    var logger = sp.GetRequiredService<ILogger<Program>>();

    var kafkaConnection = config.GetConnectionString("KafkaConnection")
        ?? throw new InvalidOperationException("KafkaConnection string is missing");

    logger.LogInformation("Connecting to Kafka at {KafkaConnection}", kafkaConnection);
    logger.LogInformation("Using topic: {Topic}", kafkaOptions.Topic);

    var producerConfig = new ProducerConfig
    {
        BootstrapServers = kafkaConnection,
        Acks = Acks.All,
        EnableIdempotence = true,
        MessageSendMaxRetries = 5,
        RetryBackoffMs = 1000,
        MessageTimeoutMs = 5000,
        LingerMs = 5,
        BatchSize = 16384
    };

    return new ProducerBuilder<Null, string>(producerConfig)
        .SetErrorHandler((_, e) =>
            logger.LogError("Kafka producer error: {Reason} (Code: {Code})", e.Reason, e.Code))
        .SetLogHandler((_, m) =>
            logger.LogDebug("Kafka log: {Message} (Level: {Level})", m.Message, m.Level))
        .Build();
});

builder.Services.AddSingleton<ContractGenerator>(sp =>
{
    var options = sp.GetRequiredService<IOptions<KafkaOptions>>().Value;
    return new ContractGenerator(options.MaxCarId, options.MaxClientId);
});

var host = builder.Build();

// Логирование при запуске
var logger = host.Services.GetRequiredService<ILogger<Program>>();
var kafkaOptions = host.Services.GetRequiredService<IOptions<KafkaOptions>>().Value;
logger.LogInformation("Starting CarRental.Kafka with configuration:");
logger.LogInformation("  Topic: {Topic}", kafkaOptions.Topic);
logger.LogInformation("  ProduceDelay: {ProduceDelayMs}ms", kafkaOptions.ProduceDelayMs);
logger.LogInformation("  MaxCarId: {MaxCarId}", kafkaOptions.MaxCarId);
logger.LogInformation("  MaxClientId: {MaxClientId}", kafkaOptions.MaxClientId);

host.Run();