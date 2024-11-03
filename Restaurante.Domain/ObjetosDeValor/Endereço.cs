using Restaurante.Domain.Entidades;

namespace Restaurante.Domain.ObjetosDeValor
{
    public class Endereço : Base
    {
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }

        private readonly IList<string> _erros = new List<string>();

        public Endereço(string rua, int numero, string cidade, string estado, string cep)
        {
            DefinirEndereço(rua, numero, cidade, estado , cep);
        }

        private void DefinirEndereço(string rua, int numero, string cidade, string estado, string cep)
        {
            ValidarEndereço(rua, numero, cidade, estado, cep);
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            CEP = FormataCEP(cep);
        }

        public void AlterarEndereço(string rua, int numero, string cidade, string estado, string cep)
        {
            ValidarEndereço(rua, numero, cidade, estado, cep);
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            CEP = FormataCEP(cep);
        }

        private void ValidarEndereço(string rua, int numero, string cidade, string estado, string cep)
        {
            string digitosCEP = new(cep.Where(char.IsDigit).ToArray());
            if (string.IsNullOrEmpty(rua))
                _erros.Add("Rua não pode ser nula ou vazia");
            if (numero <= 0)
                _erros.Add("Número não pode ser menor ou igual a zero");
            if (string.IsNullOrEmpty(cidade))
                _erros.Add("Cidade não pode ser nula ou vazia");
            if (string.IsNullOrEmpty(estado))
                _erros.Add("Estado não pode ser nulo ou vazio");
            if (digitosCEP.Length != 8)
                _erros.Add("CEP inválido");
            if (_erros.Any())
                throw new Exception(string.Join(",", _erros));
        }

        private static string FormataCEP(string cep)
        {
            string numerosTelefone = new(cep.Where(char.IsDigit).ToArray());

            string primeirosNumeros = numerosTelefone[..2];
            string parteCentral = numerosTelefone.Substring(2, 5);
            string parteFinal = numerosTelefone.Substring(5, 8);

            return $"{primeirosNumeros}`.{parteCentral}-{parteFinal}";
        }
    }
}
