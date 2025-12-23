namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for retrieving model generation information
/// </summary>
public record ModelGenerationGetDto(
    int Id,
    int Year,
    double EngineVolume,
    string Transmission,
    decimal RentalPricePerHour,
    CarModelGetDto Model
);