using Restaurante.Domain.Entidades;

namespace Restaurante.Infrastructure.Contratos;

public interface IBaseRepository<TEntity> where TEntity : Base
{
    Task<IReadOnlyList<TEntity>> ObterTodosAsync();
    Task<TEntity> ObterPorIdAsync(Guid id);
    Task AdicionarAsync(TEntity entity);
    Task AlterarAsync(TEntity entity);
    Task DeletarAsync(TEntity entity);
}
