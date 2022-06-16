using Dominio.Genericos;

namespace Dominio.Entidades.ObjetosValor
{
    public class Telefone : EntidadeBase
    {
        public int Ddd { get; set; }
        public string Numero { get; set; } = string.Empty;
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
        }
    }
}
