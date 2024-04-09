using AutoMapper;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos;
using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;

namespace Restaurante.Application;

public class ServiceBase<TDto, TReturnDto, TEntity, TRepository> : ServiceBaseExtensao<TDto, TReturnDto, TEntity, TRepository>, IServiceBase<TDto, TReturnDto>
    where TDto : class
    where TReturnDto : BaseDto
    where TEntity : Base
    where TRepository : IRepositoryBase<TEntity>
{
    protected TRepository Repository;
    protected readonly IMapper _mapper;
    protected List<string> _erros;

    public ServiceBase(TRepository repository, IMapper mapper) : base(repository, mapper)
    {
        Repository = repository;
        _mapper = mapper;
        _erros = new();
    }

    public virtual async Task AlterarAsync(TDto dto , Guid id)
    {
        ValidarValores(dto);
        var entidade = await Repository.ObterPorIdAsync(id);
        await Repository.AlterarAsync(DefinirEntidadeAlteracao(entidade, dto));
    }

    protected TEntity DefinirEntidadeAlteracao(TEntity entidade, TDto dto)
    {
        throw new NotImplementedException();
    }
}
