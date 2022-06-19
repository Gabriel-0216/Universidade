using System.Globalization;
using Dominio.Entidades.ObjetosValor;
using Dominio.Genericos;

namespace Dominio.Entidades
{
    public class Estudante : EntidadeBase
    {
        public string Nome { get; private set; } = string.Empty;
        public string Sobrenome { get; private set; } = string.Empty;
        public DateTime DataNascimento { get; private set; }
        public IList<Endereco>? Enderecos { get; private set; }
        public IList<Telefone>? Telefones { get; private set; }
        public IList<Curso>? Cursos { get; private set; }
        public IList<Contrato>? Contratos { get; private set; }

        private void Validacoes(string nome, string sobrenome, DateTime dataNascimento)
        {
            if (string.IsNullOrEmpty(nome)) AddNotification("Nome", MensagensValidacoes.PropriedadeObrigatoria);
            if (string.IsNullOrEmpty(sobrenome)) AddNotification("Sobrenome", MensagensValidacoes.PropriedadeObrigatoria);
            if (string.IsNullOrEmpty(dataNascimento.ToString(CultureInfo.InvariantCulture))) AddNotification("Data Nascimento", MensagensValidacoes.PropriedadeObrigatoria);
        }

        public Estudante()
        {
            
        }
        public Estudante(string nome, string sobrenome, DateTime dataNascimento)
        {
            Validacoes(nome, sobrenome, dataNascimento);
            if (Notifications.Count != 0) return;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            if (Cursos is null) Cursos = new List<Curso>();
        }
        public void AdicionaEndereco(Endereco endereco)
        {
            if (!endereco.IsValid || !this.IsValid) return;
            Enderecos ??= new List<Endereco>();
            Enderecos.Add(endereco);
        }
        public void RemoveEndereco(int enderecoId)
        {
            var endereco = Enderecos?.FirstOrDefault(p => p.Id == enderecoId);
            if (endereco != null) Enderecos.Remove(endereco);
        }
        public void AdicionaTelefone(Telefone telefone)
        {
            if (!telefone.IsValid || !this.IsValid) return;
            Telefones ??= new List<Telefone>();
            Telefones.Add(telefone);
        }
        public void RemoveTelefone(Telefone telefone)
        {
            if(telefone.IsValid && Telefones is not null)
            {
                Telefones.Remove(telefone);
            }
        }

        public void AdicionaCurso(Curso curso)
        {
            Cursos?.Add(curso);
        }
    }
}
