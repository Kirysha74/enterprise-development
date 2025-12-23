using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Domain.Entities;

/// <summary>
/// Represents a rental car in the system
/// </summary>
[Table("cars")]
public class Car
{
    /// <summary>
    /// Unique car identifier
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// License plate number
    /// </summary>
    [Column("license_plate")]
    [MaxLength(20)]
    public required string LicensePlate { get; set; }

    /// <summary>
    /// Car color
    /// </summary>
    [Column("color")]
    [MaxLength(30)]
    public required string Color { get; set; }

    /// <summary>
    /// Model generation identifier
    /// </summary>
    [Column("model_generation_id")]
    public required int ModelGenerationId { get; set; }

    /// <summary>
    /// Navigation property to model generation
    /// </summary>
    public ModelGeneration? ModelGeneration { get; set; }
}