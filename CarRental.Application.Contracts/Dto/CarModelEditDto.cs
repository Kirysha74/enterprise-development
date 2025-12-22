namespace CarRental.Application.Contracts.Dto;

public record CarModelEditDto(
    string Name,
    string DriveType,
    int SeatsCount,
    string BodyType,
    string Class
);