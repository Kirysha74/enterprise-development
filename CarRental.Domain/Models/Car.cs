namespace CarRental.Domain.Models;

/// <summary>
/// Car in the rental fleet
/// </summary>
public class Car
{
    /// <summary>
    /// Unique car identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// License plate number
    /// </summary>
    public required string LicensePlate { get; set; }

    /// <summary>
    /// Car color
    /// </summary>
    public required string Color { get; set; }

    /// <summary>
    /// Model generation identifier
    /// </summary>
    public required int ModelGenerationId { get; set; }

    /// <summary>
    /// Car model generation
    /// </summary>
    public required ModelGeneration ModelGeneration { get; set; }
}