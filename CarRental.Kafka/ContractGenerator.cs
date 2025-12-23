using Bogus;
using CarRental.Application.Contracts.Dto;

namespace CarRental.Kafka;

/// <summary>
/// Generates randomized rental DTOs for Kafka producing
/// </summary>
public class ContractGenerator
{
    private readonly Faker<RentalEditDto> _faker;

    public ContractGenerator(int maxCarId = 15, int maxClientId = 15)
    {
        _faker = new Faker<RentalEditDto>()
            .CustomInstantiator(f => new RentalEditDto(
                RentalDate: f.Date.Recent(30),
                RentalHours: f.Random.Int(4, 168), // от 4 часов до 7 дней
                CarId: f.Random.Int(1, maxCarId),
                ClientId: f.Random.Int(1, maxClientId)
            ));
    }

    /// <summary>
    /// Generates a new random rental DTO
    /// </summary>
    public RentalEditDto Generate()
    {
        return _faker.Generate();
    }
}