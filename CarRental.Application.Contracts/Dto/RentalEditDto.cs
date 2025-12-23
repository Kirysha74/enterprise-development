namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for creating and updating rentals
/// </summary>
public record RentalEditDto(
    DateTime RentalDate,
    int RentalHours,
    int CarId,
    int ClientId
);