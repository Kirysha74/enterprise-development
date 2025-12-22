using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Domain.Entities;

[Table("cars")]
public class Car
{
    [Column("id")]
    public int Id { get; set; }

    [Column("license_plate")]
    [MaxLength(20)]
    public required string LicensePlate { get; set; }

    [Column("color")]
    [MaxLength(30)]
    public required string Color { get; set; }

    [Column("model_generation_id")]
    public required int ModelGenerationId { get; set; }

    public ModelGeneration? ModelGeneration { get; set; }
}