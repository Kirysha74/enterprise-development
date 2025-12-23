using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Domain.Entities;

/// <summary>
/// Represents a car model
/// </summary>
[Table("car_models")]
public class CarModel
{
    /// <summary>
    /// Unique model identifier
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Model name (e.g., "BMW 3 Series")
    /// </summary>
    [Column("name")]
    [MaxLength(50)]
    public required string Name { get; set; }

    /// <summary>
    /// Drive type (FWD, RWD, AWD, 4WD)
    /// </summary>
    [Column("drive_type")]
    [MaxLength(10)]
    public required string DriveType { get; set; }

    /// <summary>
    /// Number of seats
    /// </summary>
    [Column("seats_count")]
    public required int SeatsCount { get; set; }

    /// <summary>
    /// Body type (Sedan, SUV, Coupe, etc.)
    /// </summary>
    [Column("body_type")]
    [MaxLength(20)]
    public required string BodyType { get; set; }

    /// <summary>
    /// Car class (Economy, Premium, Luxury, etc.)
    /// </summary>
    [Column("class")]
    [MaxLength(20)]
    public required string Class { get; set; }
}