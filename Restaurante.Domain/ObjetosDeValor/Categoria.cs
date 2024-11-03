using Restaurante.Domain.Entidades;

namespace Restaurante.Domain.ObjetosDeValor;

public class Categoria : Base
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public IList<ItemDoMenu> ItensDoMenu { get; set; }

    private List<string> _erros { get; set; } = new List<string>();

    public Categoria(string nome, string descricao)
    {
        DefinirCategoria(nome, descricao);
    }

    private void DefinirCategoria(string nome, string descricao)
    {
        ValidarCategoria(nome, descricao);
        Nome = nome;
        Descricao = descricao;
        ItensDoMenu = new List<ItemDoMenu>();
    }

    private void ValidarCategoria(string nome, string descricao)
    {
        if (string.IsNullOrEmpty(nome))
            _erros.Add("Nome não pode ser nulo ou vazio");
        if (string.IsNullOrEmpty(descricao))
            _erros.Add("Descrição não pode ser nulo ou vazio");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));
    }
}
