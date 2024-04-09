using System.Text.RegularExpressions;

namespace Restaurante.Domain.ObjetosDeValor
{
    public class Email
    {
        public string EnderecoEmail { get; private set; } = string.Empty;

        protected Email() { }

        public Email(string enderecoEmail)
        {
            if (!Validar(enderecoEmail))
            {
                throw new ArgumentException("Endereço de e-mail inválido", nameof(enderecoEmail));
            }

            EnderecoEmail = enderecoEmail;
        }

        public static bool Validar(string enderecoEmail)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

            if (!regexEmail.IsMatch(enderecoEmail))
            {
                throw new ArgumentException("Formato de e-mail inválido", nameof(enderecoEmail));
            }

            return true;
        }
    }
}
