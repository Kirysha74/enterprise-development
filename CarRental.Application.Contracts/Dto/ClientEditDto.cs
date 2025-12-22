namespace CarRental.Application.Contracts.Dto;

public record ClientEditDto(
    string LicenseNumber,
    string FullName,
    DateOnly BirthDate
);