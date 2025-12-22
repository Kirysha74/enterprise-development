namespace CarRental.Application.Contracts.Dto;

public record ModelGenerationGetDto(
    int Id,
    int Year,
    double EngineVolume,
    string Transmission,
    decimal RentalPricePerHour,
    int ModelId
);