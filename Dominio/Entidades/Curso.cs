using Dominio.Genericos;

namespace Dominio.Entidades
{
    public class Curso : EntidadeBase
    {
        public string Nome { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public int DuracaoMeses { get; private set; }
        public decimal ValorTotal { get; private set; }
        public IList<Estudante>? Estudantes { get; private set; }
        public IList<Contrato> Contratos { get; private set; }

        public Curso()
        {
            
        }
        public Curso(string nome, string descricao, int duracaoMeses, decimal valorTotal)
        {
            Validacoes(nome, descricao, duracaoMeses, valorTotal);
            if (Notifications.Count != 0) return;
            Nome = nome;
            Descricao = descricao;
            DuracaoMeses = duracaoMeses;
            ValorTotal = valorTotal;
            Estudantes = new List<Estudante>();
        }
        private void Validacoes(string nome, string descricao, int duracaoMeses, decimal valorTotal)
        {
            if (string.IsNullOrEmpty(nome)) AddNotification("Nome", MensagensValidacoes.PropriedadeObrigatoria);
            if (string.IsNullOrEmpty(descricao)) AddNotification("Descrição", MensagensValidacoes.PropriedadeObrigatoria);
            if (duracaoMeses <= 0) AddNotification("Duração meses", "A duração em meses não pode ser menor ou igual a zero");
            if (valorTotal < 0) AddNotification("Valor total", "O valor total não pode ser negativo.");
        }
        public void AdicionaEstudanteCurso(Estudante estudante)
        {
            if (!estudante.IsValid || !this.IsValid) return;
            Estudantes ??= new List<Estudante>();
            Estudantes.Add(estudante);
        }
        public void RemoveEstudanteCurso(Estudante estudante)
        {
            if (!estudante.IsValid || !this.IsValid) return;
            if (Estudantes is not null) Estudantes.Remove(estudante);
        }
    }
}
