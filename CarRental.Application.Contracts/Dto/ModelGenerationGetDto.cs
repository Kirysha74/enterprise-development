namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for retrieving model generation information
/// </summary>
/// <param name="Id">Unique identifier of the model generation</param>
/// <param name="Year">Production year of the model generation</param>
/// <param name="EngineVolume">Engine volume in liters</param>
/// <param name="Transmission">Transmission type (MT, AT, CVT)</param>
/// <param name="RentalPricePerHour">Rental price per hour</param>
/// <param name="Model">Car model information</param>
public record ModelGenerationGetDto(
    int Id,
    int Year,
    double EngineVolume,
    string Transmission,
    decimal RentalPricePerHour,
    CarModelGetDto Model
);