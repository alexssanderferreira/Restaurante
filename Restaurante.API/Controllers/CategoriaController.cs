using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Contratos;
using Restaurante.Application.Dtos.Categoria;

namespace Restaurante.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriaController : BaseControllerExtensao<CategoriaDto, RetornoCategoriaDto, ICategoriaService>
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService) : base(categoriaService)
    {
        _categoriaService = categoriaService;
    }
}
