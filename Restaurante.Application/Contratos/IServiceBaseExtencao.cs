using Restaurante.Application.Dtos;

namespace Restaurante.Application.Contratos;

public interface IServiceBaseExtencao<TDto, TReturnDto>
        where TDto : class
        where TReturnDto : BaseDto
{
    Task<IReadOnlyList<TReturnDto>> ObterTodosAsync();
    Task<TReturnDto> ObterPorIdAsync(Guid id);
    Task AdicionarAsync(TDto dto);
    Task DeletarAsync(Guid id);
}
