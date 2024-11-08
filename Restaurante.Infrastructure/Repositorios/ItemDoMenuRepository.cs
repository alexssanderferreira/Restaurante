using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;
using Restaurante.Infrastructure.Persistencia;

namespace Restaurante.Infrastructure.Repositorio;
public class ItemDoMenuRepository : BaseRepository<ItemDoMenu>, IItemDoMenuRepository
{
    public ItemDoMenuRepository(RestauranteContext dbContext) : base(dbContext)
    {
    }

    public async override Task<ItemDoMenu> ObterPorIdAsync(Guid id)
    {
        return await _dbContext.ItensDoMenu
            .Include(i => i.Categoria)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async override Task<IReadOnlyList<ItemDoMenu>> ObterTodosAsync()
    {
        return await _dbContext.ItensDoMenu
            .Include(i => i.Categoria)
            .ToListAsync();
    }
}
