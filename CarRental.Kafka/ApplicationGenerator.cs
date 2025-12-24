using Bogus;
using CarRental.Application.Contracts.Dto;

namespace CarRental.Kafka;

/// <summary>
/// √енератор случайных договоров аренды автомобилей дл€ отправки в Kafka
/// </summary>
/// <param name="maxCars">ћаксимальный ID автомобил€ (по умолчанию 15)</param>
/// <param name="maxClients">ћаксимальный ID клиента (по умолчанию 15)</param>
public class ContractGenerator(int maxCars = 15, int maxClients = 15)
{
    /// <summary>
    /// Faker дл€ генерации DTO аренды
    /// </summary>
    private readonly Faker<RentalEditDto> _faker = new Faker<RentalEditDto>()
        .CustomInstantiator(f => new RentalEditDto(
            RentalDate: f.Date.Recent(30), // јренда в последние 30 дней
            RentalHours: f.Random.Int(4, 168), // ќт 4 часов до 7 дней
            CarId: f.Random.Int(1, maxCars),
            ClientId: f.Random.Int(1, maxClients)
        ));

    /// <summary>
    /// √енерирует новый случайный договор аренды
    /// </summary>
    /// <returns>DTO договора аренды</returns>
    public RentalEditDto Generate()
    {
        return _faker.Generate();
    }
}