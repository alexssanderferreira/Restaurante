using Restaurante.Application.Dtos.Cartao;
using Restaurante.Application.Dtos.ItensDoPedido;
using Restaurante.Domain.Enuns;

namespace Restaurante.Application.Dtos.Pedido;

public record CriarPedidoDto(CartaoDto Cartao, List<CriarItensDoPedidoDto> ItensDoPedido);
public record RetornoPedidoDto(RetornoCartaoDto Cartao, List<RetornoItensDoPedidoDto> ItensDoPedido, DateTime Data, StatusPedido Status, double Total) : BaseDto;
