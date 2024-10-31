using Restaurante.Domain.Entidades;
using Restaurante.Domain.ObjetosDeValor;
using Restaurante.Infrastructure.Contratos;
using Restaurante.Infrastructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Repositorio;
public class ItemDoMenuRepository : RepositoryBase<ItemDoMenu>, IItemDoMenuRepository
{
    public ItemDoMenuRepository(RestauranteContext dbContext) : base(dbContext)
    {
    }
}
