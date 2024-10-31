using Restaurante.Application.Dtos.ItemDoMenu;

namespace Restaurante.Application.Contratos;
public interface IItemDoMenuService : IServiceBase<ItemDoMenuDto, ItemDoMenuReturnDto>
{
    Task AlterarCategoria(Guid idItemDoMenu, Guid idCategoria);
}
