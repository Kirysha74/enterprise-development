namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for retrieving client information
/// </summary>
public record ClientGetDto(
    int Id,
    string LicenseNumber,
    string FullName,
    DateOnly BirthDate
);