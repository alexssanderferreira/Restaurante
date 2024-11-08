using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;
using Restaurante.Infrastructure.Persistencia;

namespace Restaurante.Infrastructure.Repositorio;

public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
{
    public FuncionarioRepository(RestauranteContext dbContext) : base(dbContext)
    {
    }
}
