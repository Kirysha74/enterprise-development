using AutoMapper;
using CarRental.Application.Contracts.Dto;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

[ApiController]
[Route("api/analytics")]
public class AnalyticsController(
    IRepository<Rental> rentalsRepo,
    IRepository<Car> carsRepo,
    IRepository<Client> clientsRepo,
    IRepository<ModelGeneration> modelGenerationsRepo,
    IRepository<CarModel> carModelsRepo,
    IMapper mapper) : ControllerBase
{
    [HttpGet("clients-by-model")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ClientGetDto>>> GetClientsByModelSortedByName(
        [FromQuery] string modelName)
    {
        var rentals = await rentalsRepo.GetAllAsync();
        var cars = await carsRepo.GetAllAsync();
        var modelGenerations = await modelGenerationsRepo.GetAllAsync();
        var carModels = await carModelsRepo.GetAllAsync();
        var clients = await clientsRepo.GetAllAsync();

        var result = rentals
            .Join(cars, r => r.CarId, c => c.Id, (r, c) => new { Rental = r, Car = c })
            .Join(modelGenerations, rc => rc.Car.ModelGenerationId, mg => mg.Id, (rc, mg) => new { rc.Rental, rc.Car, ModelGeneration = mg })
            .Join(carModels, rcm => rcm.ModelGeneration.ModelId, cm => cm.Id, (rcm, cm) => new { rcm.Rental, rcm.Car, rcm.ModelGeneration, CarModel = cm })
            .Where(x => x.CarModel.Name == modelName)
            .Select(x => x.Rental.ClientId)
            .Distinct()
            .Join(clients, id => id, c => c.Id, (id, c) => c)
            .OrderBy(c => c.FullName)
            .Select(mapper.Map<ClientGetDto>)
            .ToList();

        return Ok(result);
    }

    [HttpGet("currently-rented-cars")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CarGetDto>>> GetCurrentlyRentedCars(
        [FromQuery] DateTime currentDate)
    {
        var rentals = await rentalsRepo.GetAllAsync();
        var cars = await carsRepo.GetAllAsync();

        var rentedCars = rentals
            .Where(r => r.RentalDate.AddHours(r.RentalHours) > currentDate)
            .Select(r => r.CarId)
            .Distinct()
            .Join(cars, id => id, c => c.Id, (id, c) => c)
            .Select(mapper.Map<CarGetDto>)
            .ToList();

        return Ok(rentedCars);
    }

    [HttpGet("top-5-most-rented-cars")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CarRentalCountDto>>> GetTop5MostRentedCars()
    {
        var rentals = await rentalsRepo.GetAllAsync();
        var cars = await carsRepo.GetAllAsync();

        var topCars = rentals
            .GroupBy(r => r.CarId)
            .Select(g => new { CarId = g.Key, RentalCount = g.Count() })
            .OrderByDescending(x => x.RentalCount)
            .Take(5)
            .Join(cars, x => x.CarId, c => c.Id, (x, c) => new CarRentalCountDto(
                mapper.Map<CarGetDto>(c),
                x.RentalCount))
            .ToList();

        return Ok(topCars);
    }

    [HttpGet("rental-count-per-car")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CarRentalCountDto>>> GetRentalCountPerCar()
    {
        var rentals = await rentalsRepo.GetAllAsync();
        var cars = await carsRepo.GetAllAsync();

        var carsWithRentalCount = cars
            .Select(car => new CarRentalCountDto(
                mapper.Map<CarGetDto>(car),
                rentals.Count(r => r.CarId == car.Id)))
            .OrderByDescending(x => x.RentalCount)
            .ToList();

        return Ok(carsWithRentalCount);
    }

    [HttpGet("top-5-clients-by-rental-amount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ClientRentalAmountDto>>> GetTop5ClientsByRentalAmount()
    {
        var rentals = await rentalsRepo.GetAllAsync();
        var cars = await carsRepo.GetAllAsync();
        var modelGenerations = await modelGenerationsRepo.GetAllAsync();
        var clients = await clientsRepo.GetAllAsync();

        var topClients = rentals
            .Join(cars, r => r.CarId, c => c.Id, (r, c) => new { Rental = r, Car = c })
            .Join(modelGenerations, rc => rc.Car.ModelGenerationId, mg => mg.Id, (rc, mg) => new
            {
                ClientId = rc.Rental.ClientId,
                Amount = rc.Rental.RentalHours * mg.RentalPricePerHour
            })
            .GroupBy(x => x.ClientId)
            .Select(g => new { ClientId = g.Key, TotalAmount = g.Sum(x => x.Amount) })
            .OrderByDescending(x => x.TotalAmount)
            .Take(5)
            .Join(clients, x => x.ClientId, c => c.Id, (x, c) => new ClientRentalAmountDto(
                mapper.Map<ClientGetDto>(c),
                x.TotalAmount))
            .ToList();

        return Ok(topClients);
    }
}

public record CarRentalCountDto(CarGetDto Car, int RentalCount);
public record ClientRentalAmountDto(ClientGetDto Client, decimal TotalAmount);