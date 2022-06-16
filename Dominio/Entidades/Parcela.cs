namespace Dominio.Entidades
{
    public class Parcela : EntidadeBase
    {
        public int Numero { get; private set; } 
        public Contrato? Contrato { get; private set; }
        public decimal Valor {get; private set; }
        public Pagamento? Pagamento { get; private set; }
        public bool Pago { get { return Pagamento is not null; } }
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

        public void AdicionaPagamento(Pagamento pagamento)
        {
            if (pagamento is not null && pagamento.IsValid) Pagamento = pagamento;
        }

    }
}