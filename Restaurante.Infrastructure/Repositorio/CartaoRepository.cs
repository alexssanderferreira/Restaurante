using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;
using Restaurante.Infrastructure.Persistencia;

namespace Restaurante.Infrastructure.Repositorio;
public class CartaoRepository : RepositoryBase<Cartao>, ICartaoRepository
{
    public CartaoRepository(RestauranteContext dbContext) : base(dbContext)
    {
    }
}
