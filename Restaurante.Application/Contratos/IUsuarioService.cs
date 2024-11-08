using Restaurante.Application.Dtos;

namespace Restaurante.Application.Contratos;
public interface IUsuarioService<TDto, TReturnDto>
        where TDto : class
        where TReturnDto : BaseDto
{
    Task AdicionarAsync(TDto dto);
    Task<TReturnDto> ObterPorIdAsync(Guid id);
    Task DeletarAsync(Guid id);
}
