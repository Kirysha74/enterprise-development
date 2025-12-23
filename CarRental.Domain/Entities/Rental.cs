using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Domain.Entities;

/// <summary>
/// Represents a car rental record
/// </summary>
[Table("rentals")]
public class Rental
{
    /// <summary>
    /// Unique rental identifier
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Rental start date and time
    /// </summary>
    [Column("rental_date")]
    public required DateTime RentalDate { get; set; }

    /// <summary>
    /// Rental duration in hours
    /// </summary>
    [Column("rental_hours")]
    public required int RentalHours { get; set; }

    /// <summary>
    /// Rented car identifier
    /// </summary>
    [Column("car_id")]
    public required int CarId { get; set; }

    /// <summary>
    /// Client identifier
    /// </summary>
    [Column("client_id")]
    public required int ClientId { get; set; }

    /// <summary>
    /// Navigation property to car
    /// </summary>
    public Car? Car { get; set; }

    /// <summary>
    /// Navigation property to client
    /// </summary>
    public Client? Client { get; set; }
}