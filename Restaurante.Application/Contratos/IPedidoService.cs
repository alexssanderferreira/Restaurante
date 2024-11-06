using Restaurante.Application.Dtos.ItensDoPedido;
using Restaurante.Application.Dtos.Pedido;
using Restaurante.Domain.Enuns;

namespace Restaurante.Application.Contratos;
public interface IPedidoService : IServiceBase<PedidoDto, PedidoReturnDto>
{
    Task AdicionarItemAsync(Guid id, ItensDoPedidoDto item);
    Task RemoverItemAsync(Guid id, ItensDoPedidoDto item);
    Task CancelarPedidoAsync(Guid id);
}
