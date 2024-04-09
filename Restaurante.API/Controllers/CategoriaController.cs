using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos.Categoria;
using Restaurante.Domain.ObjetosDeValor;

namespace Restaurante.API.Controllers;

public class CategoriaController : BaseControllerExtensao<Categoria, CategoriaDto, CategoriaReturnDto, ICategoriaService>
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService) : base(categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpPost]
    public override async Task<IActionResult> AdicionarAsync(CategoriaDto categoriaDto)
    {
        return Ok("Teste");
    }

    [HttpGet]
    public override async Task<IActionResult> ObterTodosAsync()
    {
        return Ok("Teste");
    }
}
