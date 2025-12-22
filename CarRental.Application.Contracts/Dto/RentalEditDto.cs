namespace CarRental.Application.Contracts.Dto;

public record RentalEditDto(
    DateTime RentalDate,
    int RentalHours,
    int CarId,
    int ClientId
);