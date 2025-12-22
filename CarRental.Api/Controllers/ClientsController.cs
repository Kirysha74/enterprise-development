using AutoMapper;
using CarRental.Application.Contracts.Dto;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientsController(
    IRepository<Client> repo,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ClientGetDto>>> GetAll()
    {
        var entities = await repo.GetAllAsync();
        var dtos = mapper.Map<IEnumerable<ClientGetDto>>(entities);
        return Ok(dtos);
    }

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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ClientGetDto>> Create([FromBody] ClientEditDto dto)
    {
        var entity = mapper.Map<Client>(dto);
        var created = await repo.AddAsync(entity);
        var resultDto = mapper.Map<ClientGetDto>(created);
        return CreatedAtAction(nameof(Get), new { id = resultDto.Id }, resultDto);
    }

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

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(int id)
    {
        await repo.DeleteAsync(id);
        return NoContent();
    }
}