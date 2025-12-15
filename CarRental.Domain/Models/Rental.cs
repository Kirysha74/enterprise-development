namespace CarRental.Domain.Models;

/// <summary>
/// Car rental agreement
/// </summary>
public class Rental
{
    /// <summary>
    /// Unique rental identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Date and time of rental start
    /// </summary>
    public required DateTime RentalDate { get; set; }

    /// <summary>
    /// Rental duration in hours
    /// </summary>
    public required int RentalHours { get; set; }

    /// <summary>
    /// Rented car identifier
    /// </summary>
    public required int CarId { get; set; }

    /// <summary>
    /// Rented car
    /// </summary>
    public required Car Car { get; set; }

    /// <summary>
    /// Client identifier
    /// </summary>
    public required int ClientId { get; set; }

    /// <summary>
    /// Client who rented the car
    /// </summary>
    public required Client Client { get; set; }
}