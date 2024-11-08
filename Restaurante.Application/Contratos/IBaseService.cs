using Restaurante.Application.Dtos;

namespace Restaurante.Application.Contratos;

public interface IBaseService<TDto, TReturnDto> : IBaseServiceExtensao<TDto, TReturnDto>
        where TDto : class
        where TReturnDto : BaseDto
{
    Task AlterarAsync(TDto dto, Guid id);
}
