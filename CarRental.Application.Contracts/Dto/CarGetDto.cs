namespace CarRental.Application.Contracts.Dto;

public record CarGetDto(
    int Id,
    string LicensePlate,
    string Color,
    int ModelGenerationId
);