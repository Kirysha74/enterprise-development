namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for retrieving client information
/// </summary>
/// <param name="Id">Unique identifier of the client</param>
/// <param name="LicenseNumber">Driver's license number</param>
/// <param name="FullName">Client's full name</param>
/// <param name="BirthDate">Client's birth date</param>
public record ClientGetDto(
    int Id,
    string LicenseNumber,
    string FullName,
    DateOnly BirthDate
);