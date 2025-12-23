namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for retrieving car information
/// </summary>
public record CarGetDto(
    int Id,
    string LicensePlate,
    string Color,
    ModelGenerationGetDto ModelGeneration
);