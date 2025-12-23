using System.ComponentModel.DataAnnotations;

namespace CarRental.Kafka;

/// <summary>
/// Represents configuration settings for Kafka integration
/// </summary>
public class KafkaOptions
{
    /// <summary>
    /// Kafka topic to publish messages to
    /// </summary>
    [Required(ErrorMessage = "Kafka topic is required")]
    public string Topic { get; set; } = "rental-contracts-topic";

    /// <summary>
    /// Delay between produced messages in milliseconds
    /// </summary>
    [Range(100, 10000, ErrorMessage = "ProduceDelayMs must be between 100 and 10000 ms")]
    public int ProduceDelayMs { get; set; } = 2000;

    /// <summary>
    /// Maximum car ID for random generation
    /// </summary>
    [Range(1, 1000, ErrorMessage = "MaxCarId must be between 1 and 1000")]
    public int MaxCarId { get; set; } = 15;

    /// <summary>
    /// Maximum client ID for random generation
    /// </summary>
    [Range(1, 1000, ErrorMessage = "MaxClientId must be between 1 and 1000")]
    public int MaxClientId { get; set; } = 15;
}