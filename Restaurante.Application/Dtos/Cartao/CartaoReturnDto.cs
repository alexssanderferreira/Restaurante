using Restaurante.Application.Dtos.Pedido;
using Restaurante.Domain.Enuns;

namespace Restaurante.Application.Dtos.Cartao;
public record CartaoReturnDto : BaseDto
{
    //public Cliente Cliente { get; private set; }
    public int Numero { get; private set; }
    public List<PedidoReturnDto> Pedidos { get; private set; }
    public double Total => Pedidos.Sum(x => x.Total);
    public bool Pago { get; private set; }
    public StatusCartao Status { get; private set; }
    public DateTime DataHoraPagamento { get; private set; }
}
