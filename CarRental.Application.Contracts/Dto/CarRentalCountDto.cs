namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for displaying car rental counts
/// </summary>
/// <param name="Car">Car information</param>
/// <param name="RentalCount">Number of rentals for this car</param>
public record CarRentalCountDto(CarGetDto Car, int RentalCount);