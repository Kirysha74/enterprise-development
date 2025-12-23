using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Domain.Entities;

/// <summary>
/// Represents a car model generation
/// </summary>
[Table("model_generations")]
public class ModelGeneration
{
    /// <summary>
    /// Unique generation identifier
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Production year
    /// </summary>
    [Column("year")]
    public required int Year { get; set; }

    /// <summary>
    /// Engine volume in liters
    /// </summary>
    [Column("engine_volume")]
    public required double EngineVolume { get; set; }

    /// <summary>
    /// Transmission type (MT, AT, CVT)
    /// </summary>
    [Column("transmission")]
    [MaxLength(10)]
    public required string Transmission { get; set; }

    /// <summary>
    /// Rental price per hour
    /// </summary>
    [Column("rental_price_per_hour")]
    public required decimal RentalPricePerHour { get; set; }

    /// <summary>
    /// Car model identifier
    /// </summary>
    [Column("model_id")]
    public required int ModelId { get; set; }

    /// <summary>
    /// Navigation property to car model
    /// </summary>
    public CarModel? Model { get; set; }
}