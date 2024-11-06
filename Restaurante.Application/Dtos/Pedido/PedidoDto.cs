using Restaurante.Application.Dtos.Cartao;
using Restaurante.Application.Dtos.ItensDoPedido;

namespace Restaurante.Application.Dtos.Pedido;
public record PedidoDto
{
    public Guid CartaoId { get; set; }
    public List<ItensDoPedidoDto> ItensDoPedido { get; set; }
}
