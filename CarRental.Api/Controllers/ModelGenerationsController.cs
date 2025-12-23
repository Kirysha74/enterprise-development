using AutoMapper;
using CarRental.Application.Contracts.Dto;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

/// <summary>
/// Controller for managing model generations
/// </summary>
[ApiController]
[Route("api/model-generations")]
public class ModelGenerationsController(
    IRepository<ModelGeneration> repo,
    IRepository<CarModel> carModelRepo,
    IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all model generations
    /// </summary>
    /// <returns>List of all model generations</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ModelGenerationGetDto>>> GetAll()
    {
        var entities = await repo.GetAllAsync();
        var dtos = mapper.Map<IEnumerable<ModelGenerationGetDto>>(entities);
        return Ok(dtos);
    }

    /// <summary>
    /// Get model generation by ID
    /// </summary>
    /// <param name="id">Generation identifier</param>
    /// <returns>Model generation</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModelGenerationGetDto>> Get(int id)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null) return NotFound();
        var dto = mapper.Map<ModelGenerationGetDto>(entity);
        return Ok(dto);
    }

    /// <summary>
    /// Create new model generation
    /// </summary>
    /// <param name="dto">Generation creation data</param>
    /// <returns>Created model generation</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModelGenerationGetDto>> Create([FromBody] ModelGenerationEditDto dto)
    {
        var carModel = await carModelRepo.GetByIdAsync(dto.ModelId);
        if (carModel == null)
            return BadRequest($"Car model with Id {dto.ModelId} does not exist.");

        var entity = mapper.Map<ModelGeneration>(dto);
        var created = await repo.AddAsync(entity);
        var resultDto = mapper.Map<ModelGenerationGetDto>(created);
        return CreatedAtAction(nameof(Get), new { id = resultDto.Id }, resultDto);
    }

    /// <summary>
    /// Update existing model generation
    /// </summary>
    /// <param name="id">Generation identifier</param>
    /// <param name="dto">Updated generation data</param>
    /// <returns>Updated model generation</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModelGenerationGetDto>> Update(int id, [FromBody] ModelGenerationEditDto dto)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null) return NotFound();

        var carModel = await carModelRepo.GetByIdAsync(dto.ModelId);
        if (carModel == null)
            return BadRequest($"Car model with Id {dto.ModelId} does not exist.");

        mapper.Map(dto, entity);
        await repo.UpdateAsync(entity);
        var resultDto = mapper.Map<ModelGenerationGetDto>(entity);
        return Ok(resultDto);
    }

    /// <summary>
    /// Delete model generation
    /// </summary>
    /// <param name="id">Generation identifier</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(int id)
    {
        await repo.DeleteAsync(id);
        return NoContent();
    }
}