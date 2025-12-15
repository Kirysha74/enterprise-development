namespace CarRental.Domain.Models;

/// <summary>
/// Car model generation with technical specifications
/// </summary>
public class ModelGeneration
{
    /// <summary>
    /// Unique generation identifier
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Generation release year
    /// </summary>
    public required int Year { get; set; }

    /// <summary>
    /// Engine volume in liters
    /// </summary>
    public required double EngineVolume { get; set; }

    /// <summary>
    /// Transmission type
    /// </summary>
    public required string Transmission { get; set; }

    /// <summary>
    /// Rental cost per hour
    /// </summary>
    public required decimal RentalPricePerHour { get; set; }

    /// <summary>
    /// Car model identifier
    /// </summary>
    public required int ModelId { get; set; }

    /// <summary>
    /// Car model
    /// </summary>
    public required CarModel Model { get; set; }
}