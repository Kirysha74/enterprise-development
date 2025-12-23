using AutoMapper;
using CarRental.Application.Contracts.Dto;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

/// <summary>
/// Controller for managing car models
/// </summary>
[ApiController]
[Route("api/car-models")]
public class CarModelsController(
    IRepository<CarModel> repo,
    IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all car models
    /// </summary>
    /// <returns>List of all car models</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CarModelGetDto>>> GetAll()
    {
        var entities = await repo.GetAllAsync();
        var dtos = mapper.Map<IEnumerable<CarModelGetDto>>(entities);
        return Ok(dtos);
    }

    /// <summary>
    /// Get car model by ID
    /// </summary>
    /// <param name="id">Model identifier</param>
    /// <returns>Car model</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CarModelGetDto>> Get(int id)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null) return NotFound();
        var dto = mapper.Map<CarModelGetDto>(entity);
        return Ok(dto);
    }

    /// <summary>
    /// Create new car model
    /// </summary>
    /// <param name="dto">Model creation data</param>
    /// <returns>Created car model</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<CarModelGetDto>> Create([FromBody] CarModelEditDto dto)
    {
        var entity = mapper.Map<CarModel>(dto);
        var created = await repo.AddAsync(entity);
        var resultDto = mapper.Map<CarModelGetDto>(created);
        return CreatedAtAction(nameof(Get), new { id = resultDto.Id }, resultDto);
    }

    /// <summary>
    /// Update existing car model
    /// </summary>
    /// <param name="id">Model identifier</param>
    /// <param name="dto">Updated model data</param>
    /// <returns>Updated car model</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CarModelGetDto>> Update(int id, [FromBody] CarModelEditDto dto)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null) return NotFound();
        mapper.Map(dto, entity);
        await repo.UpdateAsync(entity);
        var resultDto = mapper.Map<CarModelGetDto>(entity);
        return Ok(resultDto);
    }

    /// <summary>
    /// Delete car model
    /// </summary>
    /// <param name="id">Model identifier</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(int id)
    {
        await repo.DeleteAsync(id);
        return NoContent();
    }
}