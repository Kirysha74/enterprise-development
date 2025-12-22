using AutoMapper;
using CarRental.Application.Contracts.Dto;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

[ApiController]
[Route("api/cars")]
public class CarsController(
    IRepository<Car> repo,
    IRepository<ModelGeneration> modelGenerationRepo,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CarGetDto>>> GetAll()
    {
        var entities = await repo.GetAllAsync();
        var dtos = mapper.Map<IEnumerable<CarGetDto>>(entities);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CarGetDto>> Get(int id)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null) return NotFound();
        var dto = mapper.Map<CarGetDto>(entity);
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarGetDto>> Create([FromBody] CarEditDto dto)
    {
        var modelGeneration = await modelGenerationRepo.GetByIdAsync(dto.ModelGenerationId);
        if (modelGeneration == null)
            return BadRequest($"Model generation with Id {dto.ModelGenerationId} does not exist.");

        var entity = mapper.Map<Car>(dto);
        var created = await repo.AddAsync(entity);
        var resultDto = mapper.Map<CarGetDto>(created);
        return CreatedAtAction(nameof(Get), new { id = resultDto.Id }, resultDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarGetDto>> Update(int id, [FromBody] CarEditDto dto)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null) return NotFound();

        var modelGeneration = await modelGenerationRepo.GetByIdAsync(dto.ModelGenerationId);
        if (modelGeneration == null)
            return BadRequest($"Model generation with Id {dto.ModelGenerationId} does not exist.");

        mapper.Map(dto, entity);
        await repo.UpdateAsync(entity);
        var resultDto = mapper.Map<CarGetDto>(entity);
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