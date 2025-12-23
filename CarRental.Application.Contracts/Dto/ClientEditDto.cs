namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for creating and updating clients
/// </summary>
public record ClientEditDto(
    string LicenseNumber,
    string FullName,
    DateOnly BirthDate
);