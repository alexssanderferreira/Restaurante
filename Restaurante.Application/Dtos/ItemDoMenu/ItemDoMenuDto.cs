using Restaurante.Application.Dtos.Categoria;

namespace Restaurante.Application.Dtos.ItemDoMenu;

public record ItemDoMenuDto(Guid Id, string Nome, double Preco);
public record CriarItemDoMenuDto(string Nome, string Descricao, double Preco, string Imagem, Guid CategoriaId);
public record RetornoItemDoMenuDto(string Nome, string Descricao, double Preco, string Imagem, RetornoCategoriaDto Categoria) : BaseDto;

