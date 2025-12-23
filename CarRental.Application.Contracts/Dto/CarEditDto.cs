namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for creating and updating cars
/// </summary>
public record CarEditDto(
    string LicensePlate,
    string Color,
    int ModelGenerationId
);