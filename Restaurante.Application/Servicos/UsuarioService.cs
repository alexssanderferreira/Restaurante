using AutoMapper;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos;
using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;

namespace Restaurante.Application.Servicos;
public class UsuarioService<TDto, TReturnDto, TEntity, TRepository> : IUsuarioService<TDto, TReturnDto>
        where TDto : class
        where TReturnDto : BaseDto
        where TEntity : Base
        where TRepository : IBaseRepository<TEntity>
{
    protected TRepository _repository;
    protected readonly IMapper _mapper;
    protected List<string> _erros = new List<string>();

    public UsuarioService(TRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task AdicionarAsync(TDto dto)
    {
        await _repository.AdicionarAsync(await DefinirEntidadeInclusao(dto));
    }

    public virtual async Task<TReturnDto> ObterPorIdAsync(Guid id)
    {
        return _mapper.Map<TReturnDto>(await _repository.ObterPorIdAsync(id));
    }

    public async Task DeletarAsync(Guid id)
    {
        var entidade = await _repository.ObterPorIdAsync(id);
        await _repository.DeletarAsync(entidade);
    }

    protected async virtual Task<TEntity> DefinirEntidadeInclusao(TDto dto)
    {
        throw new NotImplementedException();
    }

}
