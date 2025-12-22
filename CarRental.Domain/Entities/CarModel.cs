using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Domain.Entities;

[Table("car_models")]
public class CarModel
{
	[Column("id")]
	public int Id { get; set; }

	[Column("name")]
	[MaxLength(50)]
	public required string Name { get; set; }

	[Column("drive_type")]
	[MaxLength(10)]
	public required string DriveType { get; set; }

	[Column("seats_count")]
	public required int SeatsCount { get; set; }

	[Column("body_type")]
	[MaxLength(20)]
	public required string BodyType { get; set; }

	[Column("class")]
	[MaxLength(20)]
	public required string Class { get; set; }
}