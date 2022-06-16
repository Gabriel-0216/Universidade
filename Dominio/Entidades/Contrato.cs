namespace Dominio.Entidades
{
    public class Contrato : EntidadeBase
    {
        public Curso? Curso { get; private set; }
        public Estudante? Estudante { get; private set; }
        public IList<Parcela>? Parcelas { get; private set; }
        public bool Ativo { get; private set; }
        
        public bool GerarContrato(Curso curso, Estudante estudante, int quantidadeParcelas)
        {
            if(!curso.IsValid)
            {
                AddNotification("Curso", "Não é possível gerar um contrato com um curso inválido.");
                return false;
            }
            if(!estudante.IsValid)
            {
                AddNotification("Estudante", "Não é possível gerar um contrato com um estudante inválido.");
                return false;
            }
            if(quantidadeParcelas <= 0)
            {
                AddNotification("Qtde parcelas", "Não é possível gerar um contrato sem parcelas.");
                return false;
            }
            Estudante = estudante;
            Curso = curso;
            var parcelas = GerarParcelas(curso.ValorTotal, quantidadeParcelas);
            if(parcelas.Count <= 0)
            {
                AddNotification("Parcelas", "A aplicação não conseguiu criar as parcelas.");
                return false;
            }
            if(parcelas.Count != quantidadeParcelas)
            {
                AddNotification("Parcelas", "A aplicação criou menos parcelas do que o parametrizado.");
                return false;
            }
            Parcelas = parcelas;
            Ativo = true;
            return IsValid;
        }


        private IList<Parcela> GerarParcelas(decimal valorTotal, int quantidadeParcelas)
        {
            var listaParcelas = new List<Parcela>();
            var valorParcela = valorTotal / quantidadeParcelas;
            for(int i=0; i<quantidadeParcelas; i++)
            {
                var parcela = new Parcela(i+1, this, valorParcela);
                if(parcela.IsValid) listaParcelas.Add(parcela);
            }
            return listaParcelas;
        }


    }
}