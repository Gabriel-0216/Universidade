using Dominio.Genericos;
namespace Dominio.Entidades.ObjetosValor
{
    public class Endereco : EntidadeBase
    {
        public string Cep { get; private set; } = string.Empty;
        public string Rua { get; private set; } = string.Empty;
        public string? Cidade { get; private set; } = string.Empty;
        public string? Estado { get; private set; } = string.Empty;
        public string? Numero { get; private set; } = string.Empty;
        public Estudante? Estudante { get; private set; }
        public Endereco(string cep, string rua,
            string? cidade, string? estado, string? numero)
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
            string? cidade, string? estado, string? numero)
        {
            if (string.IsNullOrEmpty(cep)) AddNotification("CEP", MensagensValidacoes.PropriedadeObrigatoria);
            if (string.IsNullOrEmpty(rua)) AddNotification("RUA", MensagensValidacoes.PropriedadeObrigatoria);
            if (string.IsNullOrEmpty(cidade)) AddNotification("Cidade", MensagensValidacoes.PropriedadeObrigatoria);
            if (string.IsNullOrEmpty(estado)) AddNotification("Estado", MensagensValidacoes.PropriedadeObrigatoria);
            if (string.IsNullOrEmpty(numero)) AddNotification("Número", MensagensValidacoes.PropriedadeObrigatoria);
            
            if(cep.Length > 20) AddNotification("CEP", "O tamanho máximo do campo é de 20 caracteres");
            if(rua.Length > 100) AddNotification("Rua", "O tamanho máximo do campo é de 100 caracteres");
            if(cidade is not null && cidade.Length > 50) AddNotification("Cidade", "O tamanho máximo do campo é 50 caracteres");
            if(estado is not null && estado.Length > 50) AddNotification("Estado", "O tamanho máximo do campo é 50 caracteres");
            if(numero is not null && numero.Length > 10) AddNotification("Número", "O tamanho máximo do campo é de 100 caracteres");
        }
    }
}
