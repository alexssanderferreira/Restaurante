using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos.ItemDoMenu;

namespace Restaurante.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ItemDoMenuController : BaseController<ItemDoMenuDto, ItemDoMenuReturnDto, IItemDoMenuService>
{
    private readonly IItemDoMenuService _itemDoMenuService;

    public ItemDoMenuController(IItemDoMenuService itemDoMenuService) : base(itemDoMenuService)
    {
        _itemDoMenuService = itemDoMenuService;
    }
}
