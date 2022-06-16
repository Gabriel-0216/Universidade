namespace Dominio.Entidades
{
    public class Parcela : EntidadeBase
    {
        public int Numero { get; set; } 
        public Contrato? Contrato { get; set; }

        public decimal Valor {get;set;}
        public Parcela(int numero, Contrato contrato, decimal valor)
        {
            Validacoes(contrato, valor);
            if(IsValid)
            {
                Contrato = contrato;
                Valor = valor;
                Numero = numero;
            }
        }
        private void Validacoes(Contrato contrato, decimal valor)
        {
            if(!contrato.IsValid) AddNotification("Contrato", "O contrato não é valido.");
            if(valor < 0) AddNotification("Valor", "O valor da parcela não é valido.");
        }

    }
}