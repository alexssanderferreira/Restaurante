using AutoMapper;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos;
using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;

namespace Restaurante.Application;

public class ServiceBaseExtensao<TDto, TReturnDto, TEntity, TRepository> : IServiceBaseExtencao<TDto, TReturnDto>
        where TDto : class
        where TReturnDto : BaseDto
        where TEntity : Base
        where TRepository : IRepositoryBase<TEntity>
{
    protected TRepository Repository;
    protected readonly IMapper _mapper;
    protected List<string> _erros;
    public ServiceBaseExtensao(TRepository repository, IMapper mapper)
    {
        Repository = repository;
        _mapper = mapper;
        _erros = new();
    }

    public virtual async Task AdicionarAsync(TDto dto)
    {
        ValidarValores(dto);
        await Repository.AdicionarAsync(DefinirEntidadeInclusao(dto));
    }

    public async Task DeletarAsync(Guid id)
    {
        var entidade = await Repository.ObterPorIdAsync(id);
        ValidarDelecao(entidade);
        await Repository.DeletarAsync(entidade);
    }

    public virtual async Task<TReturnDto> ObterPorIdAsync(Guid id)
    {
        return _mapper.Map<TReturnDto>(await Repository.ObterPorIdAsync(id));
    }

    public virtual async Task<IReadOnlyList<TReturnDto>> ObterTodosAsync()
    {
        return _mapper.Map<IReadOnlyList<TReturnDto>>(await Repository.ObterTodosAsync());
    }

    protected virtual void ValidarValores(TDto dto)
    {
        throw new NotImplementedException();
    }
    protected virtual void ValidarDelecao(TEntity entidade)
    {
        throw new NotImplementedException();
    }

    protected virtual TEntity DefinirEntidadeInclusao(TDto dto)
    {
        throw new NotImplementedException();
    }
}
