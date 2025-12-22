using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Domain.Entities;

[Table("model_generations")]
public class ModelGeneration
{
    [Column("id")]
    public int Id { get; set; }

    [Column("year")]
    public required int Year { get; set; }

    [Column("engine_volume")]
    public required double EngineVolume { get; set; }

    [Column("transmission")]
    [MaxLength(10)]
    public required string Transmission { get; set; }

    [Column("rental_price_per_hour")]
    public required decimal RentalPricePerHour { get; set; }

    [Column("model_id")]
    public required int ModelId { get; set; }

    public CarModel? Model { get; set; }
}