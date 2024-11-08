using Restaurante.Application.Dtos.ItensDoPedido;
using Restaurante.Application.Dtos.Pedido;

namespace Restaurante.Application.Contratos;
public interface IPedidoService : IBaseService<CriarPedidoDto, RetornoPedidoDto>
{
    Task AdicionarItensAsync(Guid id, List<CriarItensDoPedidoDto> itensDto);
    Task RemoverItensAsync(Guid id, List<ItensDoPedidoDto> itensDto);
    Task CancelarPedidoAsync(Guid id);
}
