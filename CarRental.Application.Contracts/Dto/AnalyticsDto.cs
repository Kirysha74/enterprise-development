namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for displaying car rental counts
/// </summary>
public record CarRentalCountDto(CarGetDto Car, int RentalCount);

/// <summary>
/// DTO for displaying client rental amounts
/// </summary>
public record ClientRentalAmountDto(ClientGetDto Client, decimal TotalAmount);