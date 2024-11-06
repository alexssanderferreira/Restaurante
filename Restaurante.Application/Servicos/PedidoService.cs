using AutoMapper;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos.ItemDoMenu;
using Restaurante.Application.Dtos.ItensDoPedido;
using Restaurante.Application.Dtos.Pedido;
using Restaurante.Domain.Entidades;
using Restaurante.Domain.Enuns;
using Restaurante.Infrastructure.Contratos;

namespace Restaurante.Application.Servicos;
public class PedidoService : ServiceBase<PedidoDto, PedidoReturnDto, Pedido, IPedidoRepository>, IPedidoService
{
    private readonly IItemDoMenuRepository _itemDoMenuRepository;
    private readonly ICartaoRepository _cartaoRepository;

    public PedidoService(IPedidoRepository repository, IMapper mapper, IItemDoMenuRepository itemDoMenuRepository, ICartaoRepository cartaoRepository) : base(repository, mapper) 
    {
        _itemDoMenuRepository = itemDoMenuRepository;
        _cartaoRepository = cartaoRepository;
    }

    public async Task AdicionarItemAsync(Guid id, ItensDoPedidoDto item)
    {
        var pedido = await _repository.ObterPorIdAsync(id);
        pedido.AdicionarItem(_mapper.Map<ItensDoPedido>(item));
        await _repository.AlterarAsync(pedido);
    }

    public async Task RemoverItemAsync(Guid id, ItensDoPedidoDto item)
    {
        var pedido = await _repository.ObterPorIdAsync(id);
        pedido.RemoverItem(_mapper.Map<ItensDoPedido>(item));
        await _repository.AlterarAsync(pedido);
    }

    public async Task CancelarPedidoAsync(Guid id)
    {
        var pedido = await _repository.ObterPorIdAsync(id);
        pedido.CancelarPedido();
        await _repository.AlterarAsync(pedido);
    }

    protected async override Task<Pedido> DefinirEntidadeInclusao(PedidoDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto), "O DTO não pode ser nulo.");

        var cartao = await _cartaoRepository.ObterPorIdAsync(dto.CartaoId);
        if (cartao == null)
            throw new Exception("Cartão não encontrado.");

        var itens = new List<ItensDoPedido>();

        foreach (var itemDto in dto.ItensDoPedido)
        {
            var itemDoMenu = await _itemDoMenuRepository.ObterPorIdAsync(itemDto.ItemDoMenuId);

            if (itemDoMenu == null)
                throw new Exception($"Item de menu com ID {itemDto.ItemDoMenuId} não encontrado.");

            var itemPedido = new ItensDoPedido(itemDoMenu, itemDto.Quantidade, itemDto.Modificacoes);
            itens.Add(itemPedido);
        }

        var pedido = new Pedido(cartao, itens);

        return pedido;
    }

    protected async Task<Pedido> DefinirEntidadeAlteracao(Guid id, StatusPedido status)
    {
        var pedido = await _repository.ObterPorIdAsync(id);

        if (pedido == null)
            throw new Exception("Pedido não encontrado.");

        pedido.AlterarStatus(status);
        return pedido;
    }
}
