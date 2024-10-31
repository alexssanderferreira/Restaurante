namespace Restaurante.Application.Dtos.ItemDoMenu;
public record ItemDoMenuDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public string Imagem { get; set; }
    public Guid CategoriaId { get; set; }
}
