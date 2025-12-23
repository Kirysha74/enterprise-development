namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for creating and updating model generations
/// </summary>
/// <param name="Year">Production year of the model generation</param>
/// <param name="EngineVolume">Engine volume in liters</param>
/// <param name="Transmission">Transmission type (MT, AT, CVT)</param>
/// <param name="RentalPricePerHour">Rental price per hour</param>
/// <param name="ModelId">Identifier of the car model</param>
public record ModelGenerationEditDto(
    int Year,
    double EngineVolume,
    string Transmission,
    decimal RentalPricePerHour,
    int ModelId
);