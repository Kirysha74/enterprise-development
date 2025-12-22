using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Domain.Entities;

[Table("clients")]
public class Client
{
    [Column("id")]
    public int Id { get; set; }

    [Column("license_number")]
    [MaxLength(20)]
    public required string LicenseNumber { get; set; }

    [Column("full_name")]
    [MaxLength(100)]
    public required string FullName { get; set; }

    [Column("birth_date")]
    public required DateOnly BirthDate { get; set; }
}