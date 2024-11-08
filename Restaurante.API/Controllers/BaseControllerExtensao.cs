using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos;

namespace Restaurante.API.Controllers;

[Route("[controller]")]
[ApiController]
public class BaseControllerExtensao< TDto, TReturnDto, TService> : ControllerBase
    where TDto : class
    where TReturnDto : BaseDto
    where TService : IBaseServiceExtensao<TDto, TReturnDto>
{
    protected readonly TService _service;

    public BaseControllerExtensao(TService service)
    {
        _service = service;
    }

    [HttpPost]
    public virtual async Task<IActionResult> AdicionarAsync(TDto dto)
    {
        try
        {
            await _service.AdicionarAsync(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    public virtual async Task<IActionResult> ObterTodosAsync()
    {
        return Ok(await _service.ObterTodosAsync());
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> ObterPorIdAsync(Guid id)
    {
        var entidade = await _service.ObterPorIdAsync(id);
        if (entidade == null)
            return NotFound();
        return Ok(entidade);
    }

    [HttpDelete]
    public async Task<IActionResult> DeletarAsync(Guid id)
    {
        try
        {
            await _service.DeletarAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
