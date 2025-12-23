namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for creating and updating model generations
/// </summary>
public record ModelGenerationEditDto(
    int Year,
    double EngineVolume,
    string Transmission,
    decimal RentalPricePerHour,
    int ModelId
);