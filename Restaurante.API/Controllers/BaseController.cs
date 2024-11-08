using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos;

namespace Restaurante.API.Controllers;

[Route("[controller]")]
[ApiController]
public class BaseController<TDto, TReturnDto, TService> : BaseControllerExtensao<TDto, TReturnDto, TService>
    where TDto : class
    where TReturnDto : BaseDto
    where TService : IBaseService<TDto, TReturnDto>
{
    protected readonly TService _service;
    public BaseController(TService service) : base(service)
    {
        _service = service;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AlterarAsync(TDto dto, Guid id)
    {
        try
        {
            await _service.AlterarAsync(dto, id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
