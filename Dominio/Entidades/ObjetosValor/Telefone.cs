using Dominio.Genericos;

namespace Dominio.Entidades.ObjetosValor
{
    public class Telefone : EntidadeBase
    {
        public int Ddd { get; set; }
        public string Numero { get; set; } = string.Empty;
        public Estudante? Estudante { get; set; }
        public Telefone(int ddd, string numero)
        {
            Validacoes(ddd, numero);
            if (IsValid)
            {
                Ddd = ddd;
                Numero = numero;
            }
        }
        private void Validacoes(int ddd, string numero)
        {
            if (string.IsNullOrEmpty(numero)) AddNotification("Número", MensagensValidacoes.PropriedadeObrigatoria);
            
            if(numero.Length > 10) AddNotification("Número", "O campo não pode ter mais que 10 caracteres");
        }
    }
}
