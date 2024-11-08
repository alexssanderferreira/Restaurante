using Restaurante.Application.Dtos.ItemDoMenu;

namespace Restaurante.Application.Dtos.ItensDoPedido;
public record ItensDoPedidoDto(Guid Id ,ItemDoMenuDto ItemDoMenu, int Quantidade, string Descricao);
public record CriarItensDoPedidoDto(ItemDoMenuDto ItemDoMenu, int Quantidade, string Descricao);
public record RetornoItensDoPedidoDto(RetornoItemDoMenuDto ItemDoMenu, int Quantidade, string Descricao) : BaseDto;
