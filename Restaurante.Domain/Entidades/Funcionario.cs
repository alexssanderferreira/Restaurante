using Restaurante.Domain.Enuns;
using Restaurante.Domain.ObjetosDeValor;

namespace Restaurante.Domain.Entidades;

public class Funcionario : Usuario
{
    public Email Email { get; private set; }
    public string Login { get; private set; }
    public string Senha { get; private set; }

    private readonly IList<string> _erros = new List<string>();

    protected Funcionario()
    {

    }

    public Funcionario(string nome, string telefone, string email, string login, string senha) : base(nome, telefone, TipoUsuario.FUNCIONARIO)
    {
        DefinirFuncionario(email, login, senha);
    }

    public void DefinirFuncionario(string email, string login, string senha)
    {
        ValidarFuncionario(email, login, senha);
        Login = login.Trim();
        Senha = senha.Trim();
        Email = new Email(email.Trim());
    }

    private bool ValidarFuncionario(string email, string login, string senha)
    {
        if (string.IsNullOrEmpty(email))
            _erros.Add("Email não pode ser nulo");
        if (string.IsNullOrEmpty(login))
            _erros.Add("Login não pode ser nulo");
        if (login.Length <= 3)
            _erros.Add("Login deve ter mais de 3 caracteres");
        if (string.IsNullOrEmpty(senha))
            _erros.Add("Senha não pode ser nulo");
        if (senha.Length < 6)
            _erros.Add("Senha deve ter no mínimo 6 caracteres");

        return !_erros.Any();
    }

}
