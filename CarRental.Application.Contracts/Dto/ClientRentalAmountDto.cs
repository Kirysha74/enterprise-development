namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for displaying client rental amounts
/// </summary>
/// <param name="Client">Client information</param>
/// <param name="TotalAmount">Total rental amount for this client</param>
public record ClientRentalAmountDto(ClientGetDto Client, decimal TotalAmount);