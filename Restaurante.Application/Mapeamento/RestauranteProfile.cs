﻿using AutoMapper;
using Restaurante.Application.Dtos.Categoria;
using Restaurante.Application.Dtos.ItemDoMenu;
using Restaurante.Application.Dtos.Pedido;
using Restaurante.Domain.Entidades;
using Restaurante.Domain.ObjetosDeValor;

namespace Restaurante.Application.Mapeamento;

public class RestauranteProfile : Profile
{
    public RestauranteProfile()
    {
        CreateMap<Categoria, RetornoCategoriaDto>();
        CreateMap<ItemDoMenu, RetornoItemDoMenuDto>();
        CreateMap<Pedido, CriarPedidoDto>();
    }
}
