namespace CarRental.Application.Contracts.Dto;

public record ModelGenerationEditDto(
    int Year,
    double EngineVolume,
    string Transmission,
    decimal RentalPricePerHour,
    int ModelId
);