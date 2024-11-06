namespace Restaurante.Domain.Entidades;

public class ItensDoPedido : Base
{
    public ItemDoMenu ItemDoMenu { get; private set; }
    public int Quantidade { get; private set; }
    public string Modificacoes { get; private set; }
    public double Total { get; private set; }

    private readonly IList<string> _erros = new List<string>();

    protected ItensDoPedido() { }

    public ItensDoPedido(ItemDoMenu itensDoMenu, int quantidade, string modificacoes)
    {
        DefinirItem(itensDoMenu, quantidade, modificacoes);
    }

    private void DefinirItem(ItemDoMenu itensDoMenu, int quantidade, string modificacoes)
    {
        ValidarItem(itensDoMenu, quantidade);
        ItemDoMenu = itensDoMenu;
        Quantidade = quantidade;
        Modificacoes = modificacoes;
        Total = ItemDoMenu.Preco*Quantidade;
    }

    private void ValidarItem(ItemDoMenu itemDoMenu, int quantidade)
    {
        if (itemDoMenu is null)
            _erros.Add("Item do menu não pode ser nulo");
        if (quantidade <= 0)
            _erros.Add("Quantidade não pode ser menor ou igual a zero");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));
    }
}
