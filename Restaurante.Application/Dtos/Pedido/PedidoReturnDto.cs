using Restaurante.Application.Dtos.Cartao;
using Restaurante.Application.Dtos.ItensDoPedido;
using Restaurante.Domain.Enuns;

namespace Restaurante.Application.Dtos.Pedido;
public record PedidoReturnDto : BaseDto
{
    public CartaoReturnDto Cartao { get; set; }
    public List<ItensDoPedidoReturnDto> ItensDoPedido { get; set; }
    public DateTime Data { get; set; }
    public StatusPedido Status { get; set; }
    public double Total { get; set; }
}
