namespace Restaurante.Application.Dtos.ItensDoPedido;
public record ItensDoPedidoDto
{
    public Guid ItemDoMenuId { get; set; }
    public int Quantidade { get; set; }
    public string Modificacoes { get; set; }
}
