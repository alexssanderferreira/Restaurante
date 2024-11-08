using Restaurante.Application.Dtos.Cliente;
using Restaurante.Application.Dtos.Pedido;
using Restaurante.Domain.Enuns;

namespace Restaurante.Application.Dtos.Cartao;

public record CartaoDto(int Numero);
public record RetornoCartaoDto(RetornoClienteDto Cliente, int Numero, List<RetornoPedidoDto> Pedidos, double Total, bool Pago, StatusCartao Status, DateTime DataHoraPagamento) : BaseDto;