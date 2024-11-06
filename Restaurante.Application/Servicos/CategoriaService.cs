using AutoMapper;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos.Categoria;
using Restaurante.Domain.ObjetosDeValor;
using Restaurante.Infrastructure.Contratos;

namespace Restaurante.Application.Servicos;

public class CategoriaService : ServiceBaseExtensao<CategoriaDto, CategoriaReturnDto, Categoria, ICategoriaRepository>, ICategoriaService
{
    public CategoriaService(ICategoriaRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected async override Task<Categoria> DefinirEntidadeInclusao(CategoriaDto dto)
    {
        var categoria = new Categoria(dto.Nome , dto.Descricao);
        if (categoria == null)
            throw new Exception("Categoria não pode ser nula");
        return categoria;
    }
}
