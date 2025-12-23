namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for creating and updating cars
/// </summary>
/// <param name="LicensePlate">License plate number of the car</param>
/// <param name="Color">Color of the car</param>
/// <param name="ModelGenerationId">Identifier of the model generation</param>
public record CarEditDto(
    string LicensePlate,
    string Color,
    int ModelGenerationId
);