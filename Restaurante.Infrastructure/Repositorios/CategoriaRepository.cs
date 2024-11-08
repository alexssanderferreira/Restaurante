using Restaurante.Domain.ObjetosDeValor;
using Restaurante.Infrastructure.Contratos;
using Restaurante.Infrastructure.Persistencia;

namespace Restaurante.Infrastructure.Repositorio;

public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(RestauranteContext dbContext) : base(dbContext)
    {
    }
}
