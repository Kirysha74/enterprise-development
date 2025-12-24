using Bogus;
using CarRental.Application.Contracts.Dto;

namespace CarRental.Kafka;

/// <summary>
/// Generates random car rental contracts for sending to Kafka.
/// </summary>
/// <param name="maxCars">Maximum car ID (default: 15)</param>
/// <param name="maxClients">Maximum client ID (default: 15)</param>
public class ContractGenerator(int maxCars = 15, int maxClients = 15)
{
    /// <summary>
    /// Faker instance for generating rental DTOs.
    /// </summary>
    private readonly Faker<RentalEditDto> _faker = new Faker<RentalEditDto>()
        .CustomInstantiator(f => new RentalEditDto(
            RentalDate: f.Date.Recent(30), // Rental within the last 30 days
            RentalHours: f.Random.Int(4, 168), // From 4 hours to 7 days
            CarId: f.Random.Int(1, maxCars),
            ClientId: f.Random.Int(1, maxClients)
        ));

    /// <summary>
    /// Generates a new random rental contract.
    /// </summary>
    /// <returns>Rental contract DTO</returns>
    public RentalEditDto Generate()
    {
        return _faker.Generate();
    }
}