namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for retrieving rental information
/// </summary>
/// <param name="Id">Unique identifier of the rental</param>
/// <param name="RentalDate">Rental start date and time</param>
/// <param name="RentalHours">Rental duration in hours</param>
/// <param name="Car">Rented car information</param>
/// <param name="Client">Client information</param>
public record RentalGetDto(
    int Id,
    DateTime RentalDate,
    int RentalHours,
    CarGetDto Car,
    ClientGetDto Client
);