using Restaurante.Application.Dtos.ItemDoMenu;

namespace Restaurante.Application.Dtos.ItensDoPedido;
public record ItensDoPedidoReturnDto : BaseDto
{
    public ItemDoMenuReturnDto ItemDoMenu { get; set; }
    public int Quantidade { get; set; }
    public string Modificacoes { get; set; }
    public double Total { get; set; }
}
