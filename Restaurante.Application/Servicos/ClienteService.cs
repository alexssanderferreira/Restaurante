using AutoMapper;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos.Cliente;
using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;

namespace Restaurante.Application.Servicos;
public class ClienteService : UsuarioService<ClienteDto, RetornoClienteDto, Cliente, IClienteRepository>, IClienteService
{
    private readonly ICartaoRepository _cartaoRepository;

    public ClienteService(IClienteRepository repository, IMapper mapper, ICartaoRepository cartaoRepository) : base(repository, mapper) 
    {
        _cartaoRepository = cartaoRepository;
    }

    protected async override Task<Cliente> DefinirEntidadeInclusao(ClienteDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto), "O DTO não pode ser nulo.");

        return new Cliente(dto.Nome, dto.Telefone);
    }
}
