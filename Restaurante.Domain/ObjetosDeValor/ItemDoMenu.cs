using Restaurante.Domain.Entidades;

namespace Restaurante.Domain.ObjetosDeValor;

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

    public ItemDoMenu(string nome, string descricao, double preco, string imagem)
    {
        DefinirItem(nome, descricao, preco, imagem);
    }
    private void DefinirItem(string nome, string descricao, double preco, string imagem)
    {
        ValidarItem(nome, descricao, preco, imagem);
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Imagem = imagem;
    }

    public void AlterarPreco(double preco)
    {
        if (preco <= 0)
            _erros.Add("Preço não pode ser menor ou igual a zero");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));
        Preco = preco;
    }

    private void ValidarItem(string nome, string descricao, double preco, string imagem)
    {
        if (string.IsNullOrEmpty(nome))
            _erros.Add("Nome não pode ser nulo ou vazio");
        if (Nome.Length > TAMANHO_MAXIMO_NOME || Nome.Length < TAMANHO_MINIMO)
            _erros.Add($"Nome não pode ser maior que {TAMANHO_MAXIMO_NOME} caracteres e nem menor que {TAMANHO_MINIMO}.");
        if (string.IsNullOrEmpty(descricao))
            _erros.Add("Descrição não pode ser nulo ou vazio");
        if (string.IsNullOrEmpty(descricao))
            _erros.Add("Nome não pode ser nulo ou vazio");
        if (Descricao.Length > TAMANHO_MAXIMO_DESCRICAO || Descricao.Length < TAMANHO_MINIMO)
            _erros.Add($"Nome não pode ser maior que {TAMANHO_MAXIMO_NOME} caracteres e nem menor que {TAMANHO_MINIMO}.");
        if (preco <= 0)
            _erros.Add("Preço não pode ser menor ou igual a zero");
        if (string.IsNullOrEmpty(imagem))
            _erros.Add("Imagem não pode ser nulo ou vazio");
        if (_erros.Any())
            throw new Exception(string.Join(",", _erros));
    }

}
