using Dominio.Genericos;

namespace Dominio.Entidades
{
    public class Pagamento : EntidadeBase
    {
        public IList<Parcela>? Parcelas { get; private set; }
        public decimal ValorTotal { get; private set; }
        public bool RealizarPagamentoValorExato(decimal valorPagamento, IList<Parcela> parcelas)
        {
            Validacoes(parcelas);
            if (!IsValid) return false; 

            var valorTotal = parcelas.Where(parcela => parcela.IsValid).Sum(parcela => parcela.Valor);
            if(valorTotal != valorPagamento)
            {
                AddNotification("Valor Total", "O valor do pagamento não quita o valor total das parcelas.");
                return false;
            }
            var parcelasQuitadas = QuitarParcela(parcelas);
            ValorTotal = valorPagamento;
            return IsValid && parcelasQuitadas;
        }
        public bool RealizarPagamentoValorDistinto(decimal valorPagamento,
            IList<Parcela> parcelas, string motivoLiberacao, string usuarioLiberacao)
        {
            Validacoes(parcelas);
            var valorTotal = parcelas.Where(p => p.IsValid == true).Select(p => p.Valor).Sum();

            if (valorPagamento >= valorTotal)
            {
                AddNotification("Valor total", "O valor do pagamento é superior ou igual ao valor das parcelas.");
                return false;
            }

            var parcelasQuitadas = QuitarParcela(parcelas);
            if (!parcelasQuitadas) return false;
            
            var liberacaoPagamento = new LiberacaoPagamento(motivoLiberacao, usuarioLiberacao, parcelas);
            if (!liberacaoPagamento.IsValid) AddNotification("Motivo liberação pagamento", MensagensValidacoes.PropriedadeObrigatoria);
            ValorTotal = valorPagamento;
            
            return IsValid && parcelasQuitadas && liberacaoPagamento.IsValid;
        }

        private void Validacoes(IList<Parcela> parcelas)
        {
            if (parcelas is null)
                AddNotification("Parcelas", "Não é possível pagar as parcelas.");
        }
        private bool QuitarParcela(IList<Parcela> parcelas)
        {
            foreach (var parcela in parcelas)
            {
                if (!parcela.IsValid)
                {
                    AddNotification("Parcela inválida", "Não pode quitar uma parcela inválida.");
                    return false;
                }
                if (!this.IsValid)
                {
                    AddNotification("Pagamento inválido", "Não pode adicionar um pagamento inválido a uma parcela.");
                    return false;
                }
                parcela.AdicionaPagamento(this);
            }
            return true;
        }
    }
}