using Xunit;
using CarRental.Domain.Data;
using CarRental.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Tests;

public class CarRentalTests
{
    private readonly List<CarModel> _models;
    private readonly List<ModelGeneration> _generations;
    private readonly List<Car> _cars;
    private readonly List<Client> _clients;
    private readonly List<Rental> _rentals;

    public CarRentalTests()
    {
        _models = TestData.CarModels;
        _generations = TestData.ModelGenerations;
        _cars = TestData.Cars;
        _clients = TestData.Clients;
        _rentals = TestData.Rentals;
    }

    [Fact]
    public void GetClientsByModel_SortedByName()
    {
        const string targetModel = "Lada Vesta";
        const int expectedCount = 3;
        const string expectedFirstName = "Козловский Игорь Михайлович";
        const string expectedSecondName = "Попов Денис Олегович";
        const string expectedThirdName = "Смирнов Александр Петрович";

        var clients = _rentals
            .Where(r => r.Car.ModelGeneration.Model.Name == targetModel)
            .Select(r => r.Client)
            .Distinct()
            .OrderBy(c => c.FullName)
            .ToList();

        Assert.Equal(expectedCount, clients.Count);
        Assert.Equal(expectedFirstName, clients[0].FullName);
        Assert.Equal(expectedSecondName, clients[1].FullName);
        Assert.Equal(expectedThirdName, clients[2].FullName);
    }

    [Fact]
    public void GetCurrentlyRentedCars()
    {
        var testDate = new DateTime(2024, 3, 5, 12, 0, 0);
        const int expectedCount = 1;
        var expectedPlates = new[] { "К234МР163" };

        var rentedCars = _rentals
            .Where(r => r.RentalDate.AddHours(r.RentalHours) > testDate)
            .Select(r => r.Car)
            .Distinct()
            .ToList();

        Assert.Equal(expectedCount, rentedCars.Count);

        foreach (var expectedPlate in expectedPlates)
        {
            Assert.Contains(rentedCars, c => c.LicensePlate == expectedPlate);
        }
    }

    [Fact]
    public void GetTop5MostRentedCars()
    {
        const int expectedCount = 5;
        const string expectedTopCarPlate = "Н456РС163";
        const int expectedTopCarRentalCount = 3;

        var topCars = _rentals
            .GroupBy(r => r.Car)
            .Select(g => new { Car = g.Key, RentalCount = g.Count() })
            .OrderByDescending(x => x.RentalCount)
            .Take(5)
            .ToList();

        Assert.Equal(expectedCount, topCars.Count);
        Assert.Equal(expectedTopCarPlate, topCars[0].Car.LicensePlate);
        Assert.Equal(expectedTopCarRentalCount, topCars[0].RentalCount);
    }

    [Fact]
    public void GetRentalCountPerCar()
    {
        const int expectedTotalCars = 15;
        const int expectedLadaVestaRentalCount = 3;
        const int expectedBmwRentalCount = 2;
        const int carIdWithThreeRentals = 7;
        const int carIdWithTwoRentals = 1;

        var carsWithRentalCount = _cars
            .Select(car => new
            {
                Car = car,
                RentalCount = _rentals.Count(r => r.CarId == car.Id)
            })
            .ToList();

        Assert.Equal(expectedTotalCars, carsWithRentalCount.Count);

        var ladaVesta = carsWithRentalCount.First(c => c.Car.Id == carIdWithThreeRentals);
        var bmw = carsWithRentalCount.First(c => c.Car.Id == carIdWithTwoRentals);

        Assert.Equal(expectedLadaVestaRentalCount, ladaVesta.RentalCount);
        Assert.Equal(expectedBmwRentalCount, bmw.RentalCount);
        Assert.True(carsWithRentalCount.All(x => x.RentalCount >= 0));
    }

    [Fact]
    public void GetTop5ClientsByRentalAmount()
    {
        const int expectedCount = 5;
        const string expectedTopClientName = "Захарова Ольга Александровна";

        var topClients = _rentals
            .GroupBy(r => r.Client)
            .Select(g => new
            {
                Client = g.Key,
                TotalAmount = g.Sum(r => r.RentalHours * r.Car.ModelGeneration.RentalPricePerHour)
            })
            .OrderByDescending(x => x.TotalAmount)
            .Take(5)
            .ToList();

        Assert.Equal(expectedCount, topClients.Count);
        Assert.Equal(expectedTopClientName, topClients[0].Client.FullName);
    }
}