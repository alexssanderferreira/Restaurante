﻿using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;
using Restaurante.Infrastructure.Persistencia;

namespace Restaurante.Infrastructure.Repositorio;
public class ItemDoMenuRepository : RepositoryBase<ItemDoMenu>, IItemDoMenuRepository
{
    public ItemDoMenuRepository(RestauranteContext dbContext) : base(dbContext)
    {
    }
}
