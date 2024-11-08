using Restaurante.Application.Dtos.ItemDoMenu;

namespace Restaurante.Application.Contratos;
public interface IItemDoMenuService : IBaseService<CriarItemDoMenuDto, RetornoItemDoMenuDto>
{
    Task AlterarCategoria(Guid idItemDoMenu, Guid idCategoria);
}
