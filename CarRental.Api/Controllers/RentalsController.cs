using AutoMapper;
using CarRental.Application.Contracts.Dto;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

[ApiController]
[Route("api/rentals")]
public class RentalsController(
    IRepository<Rental> repo,
    IRepository<Car> carRepo,
    IRepository<Client> clientRepo,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<RentalGetDto>>> GetAll()
    {
        var entities = await repo.GetAllAsync();
        var dtos = mapper.Map<IEnumerable<RentalGetDto>>(entities);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RentalGetDto>> Get(int id)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null) return NotFound();
        var dto = mapper.Map<RentalGetDto>(entity);
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RentalGetDto>> Create([FromBody] RentalEditDto dto)
    {
        var car = await carRepo.GetByIdAsync(dto.CarId);
        if (car == null)
            return BadRequest($"Car with Id {dto.CarId} does not exist.");

        var client = await clientRepo.GetByIdAsync(dto.ClientId);
        if (client == null)
            return BadRequest($"Client with Id {dto.ClientId} does not exist.");

        var entity = mapper.Map<Rental>(dto);
        var created = await repo.AddAsync(entity);
        var resultDto = mapper.Map<RentalGetDto>(created);
        return CreatedAtAction(nameof(Get), new { id = resultDto.Id }, resultDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RentalGetDto>> Update(int id, [FromBody] RentalEditDto dto)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null) return NotFound();

        var car = await carRepo.GetByIdAsync(dto.CarId);
        if (car == null)
            return BadRequest($"Car with Id {dto.CarId} does not exist.");

        var client = await clientRepo.GetByIdAsync(dto.ClientId);
        if (client == null)
            return BadRequest($"Client with Id {dto.ClientId} does not exist.");

        mapper.Map(dto, entity);
        await repo.UpdateAsync(entity);
        var resultDto = mapper.Map<RentalGetDto>(entity);
        return Ok(resultDto);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(int id)
    {
        await repo.DeleteAsync(id);
        return NoContent();
    }
}