using Restaurante.Application.Dtos;

namespace Restaurante.Application.Contratos
{
    public interface IServiceBase<TDto, TReturnDto>
        where TDto : class
        where TReturnDto : BaseDto
    {
        Task<IReadOnlyList<TReturnDto>> ObterTodosAsync();
        Task<TReturnDto> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(TDto dto);
        Task AlterarAsync(TDto dto, Guid id);
        Task DeletarAsync(Guid id);
    }
}
