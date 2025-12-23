namespace CarRental.Application.Contracts.Dto;

/// <summary>
/// DTO for creating and updating car models
/// </summary>
/// <param name="Name">Name of the car model (e.g., "BMW 3 Series")</param>
/// <param name="DriveType">Drive type (FWD, RWD, AWD, 4WD)</param>
/// <param name="SeatsCount">Number of seats in the car</param>
/// <param name="BodyType">Body type (Sedan, SUV, Coupe, etc.)</param>
/// <param name="Class">Car class (Economy, Premium, Luxury, etc.)</param>
public record CarModelEditDto(
    string Name,
    string DriveType,
    int SeatsCount,
    string BodyType,
    string Class
);