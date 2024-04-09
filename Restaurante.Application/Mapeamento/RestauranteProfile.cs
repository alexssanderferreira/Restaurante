using AutoMapper;
using Restaurante.Application.Dtos.Categoria;
using Restaurante.Domain.ObjetosDeValor;

namespace Restaurante.Application.Mapeamento;

public class RestauranteProfile : Profile
{
    public RestauranteProfile()
    {
        CreateMap<Categoria, CategoriaDto>().ReverseMap();
    }
}
