namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for retrieving rental information
/// </summary>
public record RentalGetDto(
    int Id,
    DateTime RentalDate,
    int RentalHours,
    CarGetDto Car,
    ClientGetDto Client
);