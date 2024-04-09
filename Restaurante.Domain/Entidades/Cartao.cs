using Restaurante.Domain.Enuns;

namespace Restaurante.Domain.Entidades;

public class Cartao : Base
{
    public Cliente Cliente { get; private set; }
    public int Numero { get; private set; }
    public List<Pedido> Pedidos { get; private set; }
    public double Total { get => Pedidos.Sum(x => x.Total); }
    public bool Pago { get; private set; }
    public StatusCartao Status { get; private set; }
    public DateTime DataHoraPagamento { get; private set; }

    private readonly IList<string> _erros = new List<string>();

    public Cartao(int numero)
    {
        Numero = numero;
        Status = StatusCartao.Inativo;
    }

    public void AssociarCliente(Cliente cliente)
    {
        if (cliente is null)
            _erros.Add("Usuário não pode ser nulo");
        if (Cliente is not null)
            _erros.Add("Um usuário está vinculado ao cartão");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));


        Cliente = cliente;
        Status = StatusCartao.Ativo;
    }

    public List<Pedido> GetPedidos()
    {
        return Pedidos;
    }

    public void AdicionarPedido(Pedido pedido, List<Pedido> pedidos)
    {
        ValidarAdicionarPedido(pedido);
        pedidos.Add(pedido);
    }

    private void ValidarAdicionarPedido(Pedido pedido)
    {
        if (Pago)
            _erros.Add("Cartão já foi pago");
        if (Cliente is null)
            _erros.Add("Usuário não pode ser nulo");
        if (Status == StatusCartao.Inativo)
            _erros.Add("Cartão está inativo");
        if (pedido is null)
            _erros.Add("Pedido não pode ser nulo");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));
    }

    public void Pagar()
    {
        Pago = true;
        DataHoraPagamento = DateTime.UtcNow;
    }

    public void Bloquear()
    {
        Status = StatusCartao.Bloqueado;
    }

    public void Desbloquear()
    {
        Status = StatusCartao.Ativo;
    }

    public string VerificarSaida()
    {
        ValidarSaida();
        Status = StatusCartao.Inativo;
        Cliente = null;
        Pedidos = null;
        return $"Saída Liberada, Cartão {Numero} foi desvinculado do usuário {Cliente?.Nome}";
    }

    public void ValidarSaida()
    {
        if (Status == StatusCartao.Inativo)
            _erros.Add("Cartão está inativo");
        if (Status == StatusCartao.Bloqueado)
            _erros.Add("Cartão está bloqueado");
        if (!Pago)
            _erros.Add("Cartão não foi pago");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));
    }
}
