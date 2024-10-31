using AutoMapper;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos.Categoria;
using Restaurante.Domain.ObjetosDeValor;
using Restaurante.Infrastructure.Contratos;

namespace Restaurante.Application.Servicos;

public class CategoriaService : ServiceBaseExtensao<CategoriaDto, CategoriaReturnDto, Categoria, ICategoriaRepository>, ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IMapper _mapper;

    public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper) : base(categoriaRepository, mapper)
    {
        _categoriaRepository = categoriaRepository;
        _mapper = mapper;
    }

    protected async override Task<Categoria> DefinirEntidadeInclusao(CategoriaDto dto)
    {
        var categoria = new Categoria(dto.Nome , dto.Descricao);
        return categoria;
    }
}
