namespace Restaurante.Domain.Entidades;

public class ItensDoPedido : Base
{
    public Pedido Pedido { get; set; }
    public ItemDoMenu ItemDoMenu { get; set; }
    public int Quantidade { get; set; }
    public string Modificacoes { get; set; }
    public double Total { get; set; }

    private readonly IList<string> _erros = new List<string>();

    protected ItensDoPedido() { }

    public ItensDoPedido(Pedido pedido, ItemDoMenu itensDoMenu, int quantidade, string modificacoes, double precoUnitario)
    {
        DefinirItem(pedido, itensDoMenu, quantidade, modificacoes, precoUnitario);
    }

    private void DefinirItem(Pedido pedido, ItemDoMenu itensDoMenu, int quantidade, string modificacoes, double precoUnitario)
    {
        ValidarItem(pedido, itensDoMenu, quantidade, precoUnitario);
        Pedido = pedido;
        ItemDoMenu = itensDoMenu;
        Quantidade = quantidade;
        Modificacoes = modificacoes;
        Total = ItemDoMenu.Preco*Quantidade;
    }

    private void ValidarItem(Pedido pedido, ItemDoMenu itemDoMenu, int quantidade, double precoUnitario)
    {
        if (pedido is null)
            _erros.Add("Pedido não pode ser nulo");
        if (itemDoMenu is null)
            _erros.Add("Item do menu não pode ser nulo");
        if (quantidade <= 0)
            _erros.Add("Quantidade não pode ser menor ou igual a zero");
        if (precoUnitario <= 0)
            _erros.Add("Preço unitário não pode ser menor ou igual a zero");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));
    }
}
