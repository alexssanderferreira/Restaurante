using Restaurante.Domain.ObjetosDeValor;

namespace Restaurante.Domain.Entidades;

public class ItemDoMenu : Base
{
    const int TAMANHO_MAXIMO_NOME = 50;
    const int TAMANHO_MAXIMO_DESCRICAO = 100;
    const int TAMANHO_MINIMO = 5;

    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public double Preco { get; private set; }
    public string Imagem { get; private set; }
    public Categoria Categoria { get; set; }

    private readonly IList<string> _erros = new List<string>();

    private ItemDoMenu() { }

    public ItemDoMenu(string nome, string descricao, double preco, string imagem, Categoria categoria)
    {
        DefinirItem(nome, descricao, preco, imagem, categoria);
    }
    private void DefinirItem(string nome, string descricao, double preco, string imagem, Categoria categoria)
    {
        ValidarItem(nome, descricao, preco, imagem);
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Imagem = imagem;
        Categoria = categoria;
    }

    public void AlterarItemDoMenu(string nome, string descricao, double preco, string imagem, Categoria categoria)
    {
        ValidarItem(nome, descricao, preco, imagem);
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Imagem = imagem;
        Categoria = categoria;
    }

    private void ValidarItem(string nome, string descricao, double preco, string imagem)
    {
        if (string.IsNullOrEmpty(nome))
            _erros.Add("Nome não pode ser nulo ou vazio");
        if (string.IsNullOrEmpty(descricao))
            _erros.Add("Descrição não pode ser nulo ou vazio");
        if (nome.Length > TAMANHO_MAXIMO_NOME || nome.Length < TAMANHO_MINIMO)
            _erros.Add($"Nome não pode ser maior que {TAMANHO_MAXIMO_NOME} caracteres e nem menor que {TAMANHO_MINIMO}.");
        if (descricao.Length > TAMANHO_MAXIMO_DESCRICAO || descricao.Length < TAMANHO_MINIMO)
            _erros.Add($"Nome não pode ser maior que {TAMANHO_MAXIMO_NOME} caracteres e nem menor que {TAMANHO_MINIMO}.");
        if (preco <= 0)
            _erros.Add("Preço não pode ser menor ou igual a zero");
        if (string.IsNullOrEmpty(imagem))
            _erros.Add("Imagem não pode ser nulo ou vazio");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));
    }

}
