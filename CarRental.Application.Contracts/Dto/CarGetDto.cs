namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for retrieving car information
/// </summary>
/// <param name="Id">Unique identifier of the car</param>
/// <param name="LicensePlate">License plate number of the car</param>
/// <param name="Color">Color of the car</param>
/// <param name="ModelGeneration">Model generation information including model details</param>
public record CarGetDto(
    int Id,
    string LicensePlate,
    string Color,
    ModelGenerationGetDto ModelGeneration
);