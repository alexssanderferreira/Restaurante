using Restaurante.Domain.Enuns;

namespace Restaurante.Domain.Entidades;

public class Cliente : Usuario
{
    protected Cliente()
    {

    }
    public Cliente(string nome, string telefone) : base(nome, telefone, TipoUsuario.CLIENTE)
    {
    }
}
