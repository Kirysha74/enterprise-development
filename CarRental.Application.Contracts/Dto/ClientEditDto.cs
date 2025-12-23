namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for creating and updating clients
/// </summary>
/// <param name="LicenseNumber">Driver's license number</param>
/// <param name="FullName">Client's full name</param>
/// <param name="BirthDate">Client's birth date</param>
public record ClientEditDto(
    string LicenseNumber,
    string FullName,
    DateOnly BirthDate
);