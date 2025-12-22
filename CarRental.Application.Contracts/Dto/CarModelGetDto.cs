namespace CarRental.Application.Contracts.Dto;

public record CarModelGetDto(
    int Id,
    string Name,
    string DriveType,
    int SeatsCount,
    string BodyType,
    string Class
);