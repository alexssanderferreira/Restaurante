using AutoMapper;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos.Categoria;
using Restaurante.Domain.ObjetosDeValor;
using Restaurante.Infrastructure.Contratos;

namespace Restaurante.Application;

public class CategoriaService : ServiceBase<CategoriaDto, CategoriaReturnDto, Categoria, ICategoriaRepository>, ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IMapper _mapper;

    public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper) : base(categoriaRepository, mapper)
    {
        _categoriaRepository = categoriaRepository;
        _mapper = mapper;
    }
}
