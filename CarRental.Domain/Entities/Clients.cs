using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Domain.Entities;

/// <summary>
/// Represents a rental client
/// </summary>
[Table("clients")]
public class Client
{
    /// <summary>
    /// Unique client identifier
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Driver's license number
    /// </summary>
    [Column("license_number")]
    [MaxLength(20)]
    public required string LicenseNumber { get; set; }

    /// <summary>
    /// Client's full name
    /// </summary>
    [Column("full_name")]
    [MaxLength(100)]
    public required string FullName { get; set; }

    /// <summary>
    /// Client's birth date
    /// </summary>
    [Column("birth_date")]
    public required DateOnly BirthDate { get; set; }
}