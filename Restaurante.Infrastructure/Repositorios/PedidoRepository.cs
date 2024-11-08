using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;
using Restaurante.Infrastructure.Persistencia;

namespace Restaurante.Infrastructure.Repositorio;
internal class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
{
    public PedidoRepository(RestauranteContext dbContext) : base(dbContext)
    {
    }
}
