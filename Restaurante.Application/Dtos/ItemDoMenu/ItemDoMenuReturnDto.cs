using Restaurante.Application.Dtos.Categoria;

namespace Restaurante.Application.Dtos.ItemDoMenu;
public record ItemDoMenuReturnDto : BaseDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public string Imagem { get; set; }
    public CategoriaReturnDto Categoria { get; set; }
}
