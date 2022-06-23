namespace Dominio.Entidades
{
    public class Parcela : EntidadeBase
    {
        public int Numero { get; private set; } 
        public Contrato? Contrato { get; private set; }
        public decimal Valor {get; private set; }
        public DateTime DataVencimento { get; private set; }
        public Pagamento? Pagamento { get; private set; }
        public bool Pago { get; private set; }
        //public LiberacaoPagamento? LiberacaoPagamento { get; set; }

        public Parcela()
        {
            
        }
        public Parcela(int numero, Contrato contrato, decimal valor, DateTime dataVencimento)
        {
            Validacoes(contrato, valor);
            if (!IsValid) return;
            Contrato = contrato;
            Valor = valor;
            Numero = numero;
            DataVencimento = dataVencimento;
        }
        private void Validacoes(Contrato contrato, decimal valor)
        {
            if(!contrato.IsValid) AddNotification("Contrato", "O contrato não é valido.");
            switch (valor)
            {
                case < 0:
                    AddNotification("Valor", "O valor da parcela não pode ser negativo.");
                    break;
                case > 0 and <= 2:
                    AddNotification("Valor", "O valor mínimo da parcela é R$ 2.00");
                    break;
            }
        }

        public void AdicionaPagamento(Pagamento pagamento)
        {
            if (!pagamento.IsValid) return;
            Pagamento = pagamento;
            Pago = true;
        }

    }
}