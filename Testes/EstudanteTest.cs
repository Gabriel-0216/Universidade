using Dominio.Entidades;
using Xunit;
using System;
using Dominio.Entidades.ObjetosValor;
namespace Testes
{
    public class EstudanteTest
    {
        private Estudante EstudanteValido() => new Estudante("Gabriel", "Nascimento", DateTime.Now);
        [Fact]
        public void CriaEstudanteInvalidoSobrenome()
        {
            var estudante = new Estudante("Gabriel", "", DateTime.Now);
            Assert.False(estudante.IsValid);
        }
        [Fact]
        public void CriaEstudanteInvalidoNome()
        {
            var estudante = new Estudante("", "Nascimento", DateTime.Now);
            Assert.False(estudante.IsValid);
        }
        [Fact]
        public void CriaEstudantesInvalido()
        {
            var estudante = new Estudante("", "", DateTime.Now);
            Assert.False(estudante.IsValid);
        }
        [Fact]
        public void CriaEstudanteValido()
        {
            var estudante = EstudanteValido();
            Assert.True(estudante.IsValid);
        }
        [Fact]
        public void AdicionaEnderecoEstudante()
        {
            var estudante = EstudanteValido();
            var endereco = new Endereco("CEP", "Rua", "cidade", "estado", "123");
            estudante.AdicionaEndereco(endereco);
            Assert.True(endereco.IsValid && estudante.Enderecos?.Count > 0);
        }
        [Fact]
        public void RemoveEnderecoEstudante()
        {
            var estudante = EstudanteValido();
            var endereco = new Endereco("CEP", "Rua", "cidade", "estado", "123");
            estudante.AdicionaEndereco(endereco);
            estudante.RemoveEndereco(0);
            Assert.True(endereco.IsValid && estudante.Enderecos?.Count == 0);
        }
        [Fact]
        public void AdicionaTelefone()
        {
            var estudante = EstudanteValido();
            var telefone = new Telefone(222, "1231321");
            estudante.AdicionaTelefone(telefone);
            Assert.True(estudante.IsValid && estudante.Telefones?.Count > 0);
        }
        [Fact]
        public void RemoveTelefone()
        {
            var estudante = EstudanteValido();
            var telefone = new Telefone(222, "1231321");
            estudante.AdicionaTelefone(telefone);
            estudante.RemoveTelefone(telefone);
            Assert.True(estudante.IsValid && estudante.Telefones?.Count == 0);
        }
        [Fact]
        public void AdicionaTelefoneInvalido()
        {
            var estudante = EstudanteValido();
            var telefone = new Telefone(0, "");
            estudante.AdicionaTelefone(telefone);
            Assert.True(estudante.IsValid && (estudante.Telefones is null || estudante.Telefones?.Count == 0));
        }
        [Fact]
        public void AdicionaEnderecoInvalido()
        {
            var estudante = EstudanteValido();
            var endereco = new Endereco("", "", "cidade", "estado", "123");
            estudante.AdicionaEndereco(endereco);
            Assert.True(estudante.IsValid && (estudante.Enderecos is null || estudante.Enderecos?.Count == 0));

        }
    }
}
