using Dominio.Genericos;
namespace Dominio.Entidades.ObjetosValor
{
    public class Endereco : EntidadeBase
    {
        public string Cep { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public Endereco(string cep, string rua,
            string cidade, string estado, string numero)
        {
            Validacoes(cep, rua, cidade, estado, numero);
            if(Notifications.Count == 0)
            {
                Cep = cep;
                Rua = rua;
                Cidade = cidade;
                Estado = estado;
                Numero = numero;
            }
        }
        private void Validacoes(string cep, string rua,
            string cidade, string estado, string numero)
        {
            if (string.IsNullOrEmpty(cep)) AddNotification("CEP", MensagensValidacoes.PropriedadeObrigatoria);
            if (string.IsNullOrEmpty(rua)) AddNotification("RUA", MensagensValidacoes.PropriedadeObrigatoria);
            if (string.IsNullOrEmpty(cidade)) AddNotification("Cidade", MensagensValidacoes.PropriedadeObrigatoria);
            if (string.IsNullOrEmpty(estado)) AddNotification("Estado", MensagensValidacoes.PropriedadeObrigatoria);
            if (string.IsNullOrEmpty(numero)) AddNotification("Número", MensagensValidacoes.PropriedadeObrigatoria);
        }
    }
}
