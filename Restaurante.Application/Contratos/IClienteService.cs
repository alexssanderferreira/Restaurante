using Restaurante.Application.Dtos.Cliente;

namespace Restaurante.Application.Contratos;
public interface IClienteService : IUsuarioService<ClienteDto, RetornoClienteDto>
{
}
