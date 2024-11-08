using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;
using Restaurante.Infrastructure.Persistencia;

namespace Restaurante.Infrastructure.Repositorio;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Base
{
    protected readonly RestauranteContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(RestauranteContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = dbContext.Set<TEntity>();
    }

    public virtual async Task AdicionarAsync(TEntity entity)
    {
        _dbSet.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AlterarAsync(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletarAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IReadOnlyList<TEntity>> ObterTodosAsync()
    {
        return await _dbSet.ToListAsync();
    }
}
