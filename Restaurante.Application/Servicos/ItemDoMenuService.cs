using AutoMapper;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos.ItemDoMenu;
using Restaurante.Domain.Entidades;
using Restaurante.Infrastructure.Contratos;

namespace Restaurante.Application.Servicos;
public class ItemDoMenuService : ServiceBase<CriarItemDoMenuDto, RetornoItemDoMenuDto, ItemDoMenu, IItemDoMenuRepository>, IItemDoMenuService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public ItemDoMenuService(IItemDoMenuRepository repostory, IMapper mapper, ICategoriaRepository categoriaRepository) : base(repostory, mapper)
    {
        _categoriaRepository = categoriaRepository;
    }

    protected async override Task<ItemDoMenu> DefinirEntidadeInclusao(CriarItemDoMenuDto dto)
    {
        var categoria = await _categoriaRepository.ObterPorIdAsync(dto.CategoriaId);

        if (categoria == null)
            throw new Exception("Categoria não encontrada");

        var itemDoMenu = new ItemDoMenu(dto.Nome, dto.Descricao, dto.Preco, dto.Imagem, categoria);

        return itemDoMenu;
    }

    protected async Task<ItemDoMenu> DefinirEntidadeAlteracao(ItemDoMenu entidade, CriarItemDoMenuDto dto, Guid id)
    {
        var itemDoMenu = await _repository.ObterPorIdAsync(id);

        if (itemDoMenu == null)
            throw new Exception("Item do menu não encontrado");

        itemDoMenu.AlterarItemDoMenu(dto.Nome, dto.Descricao, dto.Preco, dto.Imagem, entidade.Categoria);

        return itemDoMenu;
    }

    public async Task AlterarCategoria(Guid idItemDoMenu, Guid idCategoria)
    {
        var itemDoMenu = await _repository.ObterPorIdAsync(idItemDoMenu);
        var categoria = await _categoriaRepository.ObterPorIdAsync(idCategoria);

        if (itemDoMenu == null)
            _erros.Add("Item do menu não encontrado");
        if (categoria == null)
            _erros.Add("Categoria não encontrado");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));

        itemDoMenu.AlterarItemDoMenu(itemDoMenu.Nome, itemDoMenu.Descricao, itemDoMenu.Preco, itemDoMenu.Imagem, categoria);
        await _repository.AlterarAsync(itemDoMenu);
    }
}

