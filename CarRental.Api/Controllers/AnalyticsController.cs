using AutoMapper;
using CarRental.Application.Contracts.Dto;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Api.Controllers;

/// <summary>
/// Controller for analytical queries and reports
/// </summary>
[ApiController]
[Route("api/analytics")]
public class AnalyticsController(
    IRepository<Rental> rentalsRepo,
    IRepository<Car> carsRepo,
    IMapper mapper) : ControllerBase
{
    [HttpGet("clients-by-model")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ClientGetDto>>> GetClientsByModelSortedByName(
        [FromQuery] string modelName)
    {
        var rentalsQuery = rentalsRepo.GetQueryable(
            include: query => query
                .Include(r => r.Car)
                    .ThenInclude(c => c!.ModelGeneration)
                        .ThenInclude(mg => mg!.Model)
                .Include(r => r.Client));

        var clients = await rentalsQuery
            .Where(r => r.Car != null &&
                       r.Car.ModelGeneration != null &&
                       r.Car.ModelGeneration.Model != null &&
                       r.Car.ModelGeneration.Model.Name == modelName)
            .Select(r => r.Client)
            .Where(client => client != null)
            .Distinct()
            .OrderBy(c => c!.FullName)
            .ToListAsync();

        var result = clients
            .Where(client => client != null)
            .Select(client => mapper.Map<ClientGetDto>(client!))
            .ToList();

        return Ok(result);
    }

    /// <summary>
    /// Get currently rented cars
    /// </summary>
    /// <param name="currentDate">Current date for checking</param>
    /// <returns>List of rented cars</returns>
    [HttpGet("currently-rented-cars")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CarGetDto>>> GetCurrentlyRentedCars(
        [FromQuery] DateTime currentDate)
    {
        var rentals = await rentalsRepo.GetAllAsync(
            include: query => query.Include(r => r.Car));

        var rentedCars = rentals
            .Where(r => r.Car != null && r.RentalDate.AddHours(r.RentalHours) > currentDate)
            .Select(r => r.Car!)
            .Distinct()
            .Select(car => mapper.Map<CarGetDto>(car))
            .ToList();

        return Ok(rentedCars);
    }

    /// <summary>
    /// Get top 5 most rented cars
    /// </summary>
    /// <returns>List of cars with rental counts</returns>
    [HttpGet("top-5-most-rented-cars")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CarRentalCountDto>>> GetTop5MostRentedCars()
    {
        var rentals = await rentalsRepo.GetAllAsync(
            include: query => query.Include(r => r.Car));

        var topCars = rentals
            .Where(r => r.Car != null)
            .GroupBy(r => r.Car!)
            .Select(g => new { Car = g.Key, RentalCount = g.Count() })
            .OrderByDescending(x => x.RentalCount)
            .Take(5)
            .Select(x => new CarRentalCountDto(
                mapper.Map<CarGetDto>(x.Car),
                x.RentalCount))
            .ToList();

        return Ok(topCars);
    }

    /// <summary>
    /// Get rental count for each car
    /// </summary>
    /// <returns>List of all cars with rental counts</returns>
    [HttpGet("rental-count-per-car")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CarRentalCountDto>>> GetRentalCountPerCar()
    {
        var rentals = await rentalsRepo.GetAllAsync();
        var cars = await carsRepo.GetAllAsync(
            include: query => query.Include(c => c.ModelGeneration));

        var carsWithRentalCount = cars
            .Select(car => new CarRentalCountDto(
                mapper.Map<CarGetDto>(car),
                rentals.Count(r => r.CarId == car.Id)))
            .OrderByDescending(x => x.RentalCount)
            .ToList();

        return Ok(carsWithRentalCount);
    }

    /// <summary>
    /// Get top 5 clients by total rental amount
    /// </summary>
    /// <returns>List of clients with total rental amounts</returns>
    [HttpGet("top-5-clients-by-rental-amount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ClientRentalAmountDto>>> GetTop5ClientsByRentalAmount()
    {
        var rentals = await rentalsRepo.GetAllAsync(
            include: query => query
                .Include(r => r.Car)
                    .ThenInclude(c => c!.ModelGeneration)
                .Include(r => r.Client));

        var topClients = rentals
            .Where(r => r.Car != null &&
                       r.Car.ModelGeneration != null &&
                       r.Client != null)
            .Select(r => new
            {
                Client = r.Client!,
                Amount = r.RentalHours * r.Car!.ModelGeneration!.RentalPricePerHour
            })
            .GroupBy(x => x.Client)
            .Select(g => new { Client = g.Key, TotalAmount = g.Sum(x => x.Amount) })
            .OrderByDescending(x => x.TotalAmount)
            .Take(5)
            .Select(x => new ClientRentalAmountDto(
                mapper.Map<ClientGetDto>(x.Client),
                x.TotalAmount))
            .ToList();

        return Ok(topClients);
    }
}