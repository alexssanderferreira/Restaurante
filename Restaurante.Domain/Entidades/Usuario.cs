using Restaurante.Domain.Enuns;

namespace Restaurante.Domain.Entidades;

public class Usuario : Base
{
    public string Nome { get; private set; }
    public string Telefone { get; private set; }
    public TipoUsuario TipoUsuario { get; private set; }

    private readonly IList<string> _erros = new List<string>();

    protected Usuario()
    {

    }
    public Usuario(string nome, string telefone, TipoUsuario tipoUsuario) : base()
    {
        DefinirUsuario(nome, telefone, tipoUsuario);
    }

    protected IList<string> Erros()
    {
        return _erros;
    }


    public void DefinirUsuario(string nome, string telefone, TipoUsuario tipoUsuario)
    {
        ValidarUsuario(nome, telefone);
        Nome = nome.Trim();
        Telefone = FormataTelefone(telefone.Trim());
        TipoUsuario = tipoUsuario;
    }

    private static string FormataTelefone(string telefone)
    {
        string numerosTelefone = new(telefone.Where(char.IsDigit).ToArray());

        string ddd = numerosTelefone[..2];
        string primeiroDigito = numerosTelefone.Substring(2, 1);
        string parteCentral = numerosTelefone.Substring(3, 4);
        string parteFinal = numerosTelefone.Substring(7, 4);

        return $"({ddd}) {primeiroDigito} {parteCentral}-{parteFinal}";
    }

    private bool ValidarUsuario(string nome, string telefone)
    {
        string numerosTelefone = new(telefone.Where(char.IsDigit).ToArray());
        if (string.IsNullOrEmpty(nome))
            _erros.Add("Nome não pode ser nulo");
        if (nome.Length < 3)
            _erros.Add("Nome deve ter mais de 3 caracteres");
        if (numerosTelefone.Length != 11)
            _erros.Add("Telefone inválido");

        return !_erros.Any();
    }

}