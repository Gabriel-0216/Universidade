namespace Dominio.Entidades
{
    public class Pagamento
    {
        //um pagamento pode quitar N parcelas
        public IList<Parcela>? Parcelas { get; set; }
        public decimal ValorTotal { get; set; }

        public void CriarPagamento(decimal valorPagamento, IList<Parcela> parcelas)
        {
            decimal valorTotal = 0M;
            foreach(var parcela in parcelas)
            {
                if(parcela.IsValid) valorTotal += parcela.Valor;
            }
            //adicionar validacoes como valor total pra pagar diferente do valor pagamento entre outros
            
        }
    }
}