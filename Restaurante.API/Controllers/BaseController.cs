using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos;
using Restaurante.Domain.Entidades;

namespace Restaurante.API.Controllers;

[Route("[controller]")]
[ApiController]
public class BaseController<TEntity, TDto, TReturnDto, TService> : BaseControllerExtensao<TEntity, TDto, TReturnDto, TService>
    where TEntity : Base
    where TDto : class
    where TReturnDto : BaseDto
    where TService : IServiceBase<TDto, TReturnDto>
{
    public BaseController(TService appService) : base(appService)
    {
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AlterarAsync(TDto dto, Guid id)
    {
        try
        {
            await Service.AlterarAsync(dto, id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
