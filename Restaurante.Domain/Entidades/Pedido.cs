using Restaurante.Domain.Enuns;

namespace Restaurante.Domain.Entidades;

public class Pedido : Base
{
    public Cartao Cartao { get; set; }
    public List<ItensDoPedido> ItensDoPedido { get; set; }
    public DateTime Data { get; set; }
    public StatusPedido Status { get; set; }
    public double Total { get; private set; }

    private readonly IList<string> _erros = new List<string>();

    protected Pedido() { }
    public Pedido(Cartao cartao, List<ItensDoPedido> itens)
    {
        DefinirPedido(cartao, itens);
    }

    private void DefinirPedido(Cartao cartao, List<ItensDoPedido> itens)
    {
        ValidarPedido(cartao, itens);
        Cartao = cartao;
        ItensDoPedido = itens;
        Data = DateTime.UtcNow;
        Status = StatusPedido.Aguardando;
        RecalcularTotal();
    }

    public void AlterarStatus(StatusPedido status)
    {
        ValidarAlteracaoStatus(status);
        Status = status;
    }

    public void AdicionarItem(ItensDoPedido item)
    {
        ValidarMudançaItens(item);
        ItensDoPedido.Add(item);
        RecalcularTotal();
    }

    public void RemoverItem(ItensDoPedido item)
    {
        ValidarMudançaItens(item);
        ItensDoPedido.Remove(item);
        RecalcularTotal();
    }

    public void CancelarPedido()
    {
        ValidarCancelamento();
        Status = StatusPedido.Cancelado;
    }

    private static void ValidarPedido(Cartao cartao, List<ItensDoPedido> itens)
    {
        if (cartao == null)
            throw new Exception("Cartão não pode ser nulo");
        if (itens == null)
            throw new Exception("Itens não pode ser nulo");
    }

    private void ValidarAlteracaoStatus(StatusPedido status)
    {
        if (this.Status == StatusPedido.Cancelado)
            _erros.Add("Pedido já foi cancelado");
        if (this.Status == StatusPedido.Entregue)
            _erros.Add("Pedido já foi entregue");
        if (this.Status <= status)
            _erros.Add("Status não pode ser alterado para um status menor ou igual ao atual");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));
    }

    private void ValidarMudançaItens(ItensDoPedido item)
    {
        if (item == null)
            _erros.Add("Item não pode ser nulo");
        if (this.Status >= StatusPedido.EmPreparacao)
            _erros.Add("Pedido atual já está em execução, faça um novo pedido");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));
    }

    private void ValidarCancelamento()
    {
        if (this.Status == StatusPedido.Cancelado)
            _erros.Add("Pedido já foi cancelado");
        if (this.Status == StatusPedido.Entregue)
            _erros.Add("Pedido já foi entregue");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));
    }

    private void RecalcularTotal()
    {
        Total = ItensDoPedido.Sum(x => x.Total);
    }
}
