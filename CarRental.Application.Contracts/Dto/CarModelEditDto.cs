namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for creating and updating car models
/// </summary>
public record CarModelEditDto(
    string Name,
    string DriveType,
    int SeatsCount,
    string BodyType,
    string Class
);