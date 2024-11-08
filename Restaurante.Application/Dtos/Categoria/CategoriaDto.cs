namespace Restaurante.Application.Dtos.Categoria;

public record CategoriaDto(string Nome, string Descricao);
public record RetornoCategoriaDto(string Nome, string Descricao) : BaseDto;
