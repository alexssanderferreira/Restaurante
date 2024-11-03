namespace Restaurante.Application.Dtos.Categoria;

public record CategoriaReturnDto : BaseDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
}
