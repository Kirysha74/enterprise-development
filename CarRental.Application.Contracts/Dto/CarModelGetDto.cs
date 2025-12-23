namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for retrieving car model information
/// </summary>
public record CarModelGetDto(
    int Id,
    string Name,
    string DriveType,
    int SeatsCount,
    string BodyType,
    string Class
);