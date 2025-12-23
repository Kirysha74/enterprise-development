using Confluent.Kafka;

namespace CarRental.Api;

/// <summary>
/// Represents configuration settings for Kafka integration
/// </summary>
public class KafkaOptions
{
    /// <summary>
    /// Kafka topic to consume messages from
    /// </summary>
    public string Topic { get; set; } = "rental-contracts-topic";

    /// <summary>
    /// Kafka group id
    /// </summary>
    public string GroupId { get; set; } = "car-rental-group";

    /// <summary>
    /// Kafka minimal bytes fetch
    /// </summary>
    public int FetchMinBytes { get; set; } = 1;
}