using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos;
using Restaurante.Domain.Entidades;

namespace Restaurante.API.Controllers;

[Route("[controller]")]
[ApiController]
public class BaseControllerExtensao<TEntity, TDto, TReturnDto, TService> : ControllerBase
    where TEntity : Base
    where TDto : class
    where TReturnDto : BaseDto
    where TService : IServiceBase<TDto, TReturnDto>
{
    protected TService Service;

    public BaseControllerExtensao(TService appService)
    {
        Service = appService;
    }

    [HttpPost]
    public virtual async Task<IActionResult> AdicionarAsync(TDto dto)
    {
        try
        {
            await Service.AdicionarAsync(dto);
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
        return Ok(await Service.ObterTodosAsync());
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> ObterPorIdAsync(Guid id)
    {
        return Ok(await Service.ObterPorIdAsync(id));
    }

    [HttpDelete]
    public async Task<IActionResult> DeletarAsync(Guid id)
    {
        try
        {
            await Service.DeletarAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
