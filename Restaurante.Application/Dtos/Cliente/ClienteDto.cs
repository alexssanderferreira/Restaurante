namespace Restaurante.Application.Dtos.Cliente;

public record ClienteDto(string Nome, string Telefone);
public record RetornoClienteDto(string Nome, string Telefone) : BaseDto;
