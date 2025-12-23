using AutoMapper;
using CarRental.Application.Contracts.Dto;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

/// <summary>
/// Controller for managing clients
/// </summary>
[ApiController]
[Route("api/clients")]
public class ClientsController(
    IRepository<Client> repo,
    IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all clients
    /// </summary>
    /// <returns>List of all clients</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ClientGetDto>>> GetAll()
    {
        var entities = await repo.GetAllAsync();
        var dtos = mapper.Map<IEnumerable<ClientGetDto>>(entities);
        return Ok(dtos);
    }

    /// <summary>
    /// Get client by ID
    /// </summary>
    /// <param name="id">Client identifier</param>
    /// <returns>Client</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClientGetDto>> Get(int id)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null) return NotFound();
        var dto = mapper.Map<ClientGetDto>(entity);
        return Ok(dto);
    }

    /// <summary>
    /// Create new client
    /// </summary>
    /// <param name="dto">Client creation data</param>
    /// <returns>Created client</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ClientGetDto>> Create([FromBody] ClientEditDto dto)
    {
        var entity = mapper.Map<Client>(dto);
        var created = await repo.AddAsync(entity);
        var resultDto = mapper.Map<ClientGetDto>(created);
        return CreatedAtAction(nameof(Get), new { id = resultDto.Id }, resultDto);
    }

    /// <summary>
    /// Update existing client
    /// </summary>
    /// <param name="id">Client identifier</param>
    /// <param name="dto">Updated client data</param>
    /// <returns>Updated client</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClientGetDto>> Update(int id, [FromBody] ClientEditDto dto)
    {
        var entity = await repo.GetByIdAsync(id);
        if (entity == null) return NotFound();
        mapper.Map(dto, entity);
        await repo.UpdateAsync(entity);
        var resultDto = mapper.Map<ClientGetDto>(entity);
        return Ok(resultDto);
    }

    /// <summary>
    /// Delete client
    /// </summary>
    /// <param name="id">Client identifier</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(int id)
    {
        await repo.DeleteAsync(id);
        return NoContent();
    }
}