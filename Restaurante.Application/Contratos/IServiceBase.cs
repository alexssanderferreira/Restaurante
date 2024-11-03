using Restaurante.Application.Dtos;

namespace Restaurante.Application.Contratos;

public interface IServiceBase<TDto, TReturnDto> : IServiceBaseExtensao<TDto, TReturnDto>
        where TDto : class
        where TReturnDto : BaseDto
{
    Task AlterarAsync(TDto dto, Guid id);
}
