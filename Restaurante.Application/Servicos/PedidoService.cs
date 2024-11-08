using AutoMapper;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos.ItensDoPedido;
using Restaurante.Application.Dtos.Pedido;
using Restaurante.Domain.Entidades;
using Restaurante.Domain.Enuns;
using Restaurante.Infrastructure.Contratos;

namespace Restaurante.Application.Servicos;
public class PedidoService : ServiceBase<CriarPedidoDto, RetornoPedidoDto, Pedido, IPedidoRepository>, IPedidoService
{
    private readonly IItemDoMenuRepository _itemDoMenuRepository;
    private readonly ICartaoRepository _cartaoRepository;

    public PedidoService(IPedidoRepository repository, IMapper mapper, IItemDoMenuRepository itemDoMenuRepository, ICartaoRepository cartaoRepository) : base(repository, mapper) 
    {
        _itemDoMenuRepository = itemDoMenuRepository;
        _cartaoRepository = cartaoRepository;
    }

    public async Task AdicionarItensAsync(Guid id, List<CriarItensDoPedidoDto> itensDto)
    {
        var pedido = await _repository.ObterPorIdAsync(id);
        if (pedido == null)
            throw new Exception($"Pedido com Id {id} não encontrado.");

        foreach (var itemDto in itensDto)
        {
            var itemDoMenu = await _itemDoMenuRepository.ObterPorIdAsync(itemDto.ItemDoMenu.Id);
            if (itemDoMenu == null)
                throw new Exception($"Item de menu com Id {itemDto.ItemDoMenu.Id} não encontrado.");

            var itemPedido = new ItensDoPedido(itemDoMenu, itemDto.Quantidade, itemDto.Descricao);

            pedido.AdicionarItem(itemPedido);
        }

        await _repository.AlterarAsync(pedido);
    }

    public async Task RemoverItensAsync(Guid id, List<ItensDoPedidoDto> itensDto)
    {
        var pedido = await _repository.ObterPorIdAsync(id)
                     ?? throw new Exception($"Pedido com Id {id} não encontrado.");

        foreach (var itemDto in itensDto)
        {
            var item = pedido.ItensDoPedido.FirstOrDefault(i => i.Id == itemDto.Id);
            if (item == null)
                throw new Exception($"Item de pedido com Id {itemDto.Id} não encontrado.");
            pedido.RemoverItem(item);
        }

        await _repository.AlterarAsync(pedido);
    }

    public async Task CancelarPedidoAsync(Guid id)
    {
        var pedido = await _repository.ObterPorIdAsync(id);
        pedido.CancelarPedido();
        await _repository.AlterarAsync(pedido);
    }

    protected async override Task<Pedido> DefinirEntidadeInclusao(CriarPedidoDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto), "O DTO não pode ser nulo.");

        var cartao = await _cartaoRepository.ObterPorNumeroAsync(dto.Cartao.Numero);
        if (cartao == null)
            throw new Exception("Cartão não encontrado.");

        var itens = new List<ItensDoPedido>();

        foreach (var itemDto in dto.ItensDoPedido)
        {
            var itemDoMenu = await _itemDoMenuRepository.ObterPorIdAsync(itemDto.ItemDoMenu.Id);

            if (itemDoMenu == null)
                throw new Exception($"Item de menu com ID {itemDto.ItemDoMenu.Id} não encontrado.");

            var itemPedido = new ItensDoPedido(itemDoMenu, itemDto.Quantidade, itemDto.Descricao);

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
