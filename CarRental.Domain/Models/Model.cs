namespace CarRental.Domain.Models;

/// <summary>
/// Car model with specifications
/// </summary>
public class CarModel
{
    /// <summary>
    /// Unique model identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Car model name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Drive type (FWD, AWD, RWD, 4WD)
    /// </summary>
    public required string DriveType { get; set; }

    /// <summary>
    /// Number of seats
    /// </summary>
    public required int SeatsCount { get; set; }

    /// <summary>
    /// Body type (Sedan, SUV, Hatchback, Coupe, etc.)
    /// </summary>
    public required string BodyType { get; set; }

    /// <summary>
    /// Car class (Economy, Premium, Luxury, Sports, etc.)
    /// </summary>
    public required string Class { get; set; }
}