namespace CarRental.Application.Contracts.Dto;

public record ClientGetDto(
    int Id,
    string LicenseNumber,
    string FullName,
    DateOnly BirthDate
);