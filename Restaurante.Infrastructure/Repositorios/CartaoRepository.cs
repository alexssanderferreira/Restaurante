using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;
using Restaurante.Infrastructure.Persistencia;

namespace Restaurante.Infrastructure.Repositorio;
public class CartaoRepository : BaseRepository<Cartao>, ICartaoRepository
{
    public CartaoRepository(RestauranteContext dbContext) : base(dbContext)
    {
    }

    public async Task<Cartao> ObterPorNumeroAsync(int numero)
    {
        return await _dbContext.Cartoes.FirstOrDefaultAsync(c => c.Numero == numero);
    }
}
