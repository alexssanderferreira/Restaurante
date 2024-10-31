using AutoMapper;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos;
using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;

namespace Restaurante.Application.Servicos;

public class ServiceBaseExtensao<TDto, TReturnDto, TEntity, TRepository> : IServiceBaseExtensao<TDto, TReturnDto>
        where TDto : class
        where TReturnDto : BaseDto
        where TEntity : Base
        where TRepository : IRepositoryBase<TEntity>
{
    protected TRepository _repository;
    protected readonly IMapper _mapper;
    protected List<string> _erros;
    public ServiceBaseExtensao(TRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _erros = new();
    }

    public virtual async Task AdicionarAsync(TDto dto)
    {
        await _repository.AdicionarAsync(await DefinirEntidadeInclusao(dto));
    }

    public async Task DeletarAsync(Guid id)
    {
        var entidade = await _repository.ObterPorIdAsync(id);
        await _repository.DeletarAsync(entidade);
    }

    public virtual async Task<TReturnDto> ObterPorIdAsync(Guid id)
    {
        return _mapper.Map<TReturnDto>(await _repository.ObterPorIdAsync(id));
    }

    public virtual async Task<IReadOnlyList<TReturnDto>> ObterTodosAsync()
    {
        return _mapper.Map<IReadOnlyList<TReturnDto>>(await _repository.ObterTodosAsync());
    }

    protected async virtual Task<TEntity> DefinirEntidadeInclusao(TDto dto)
    {
        throw new NotImplementedException();
    }
}