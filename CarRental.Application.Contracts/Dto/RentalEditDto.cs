namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for creating and updating rentals
/// </summary>
/// <param name="RentalDate">Rental start date and time</param>
/// <param name="RentalHours">Rental duration in hours</param>
/// <param name="CarId">Identifier of the rented car</param>
/// <param name="ClientId">Identifier of the client</param>
public record RentalEditDto(
    DateTime RentalDate,
    int RentalHours,
    int CarId,
    int ClientId
);