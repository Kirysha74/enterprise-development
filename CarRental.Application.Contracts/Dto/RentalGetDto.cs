namespace CarRental.Application.Contracts.Dto;

public record RentalGetDto(
    int Id,
    DateTime RentalDate,
    int RentalHours,
    int CarId,
    int ClientId
);