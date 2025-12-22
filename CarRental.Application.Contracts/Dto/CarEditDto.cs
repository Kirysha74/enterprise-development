namespace CarRental.Application.Contracts.Dto;

public record CarEditDto(
    string LicensePlate,
    string Color,
    int ModelGenerationId
);