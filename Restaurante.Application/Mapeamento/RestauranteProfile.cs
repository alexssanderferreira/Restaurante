using AutoMapper;
using Restaurante.Application.Dtos.Categoria;
using Restaurante.Application.Dtos.ItemDoMenu;
using Restaurante.Domain.Entidades;
using Restaurante.Domain.ObjetosDeValor;

namespace Restaurante.Application.Mapeamento;

public class RestauranteProfile : Profile
{
    public RestauranteProfile()
    {
        CreateMap<Categoria, CategoriaReturnDto>();
        CreateMap<ItemDoMenu, ItemDoMenuReturnDto>();

    }
}
