using Dominio.Entidades;
using System;
using Xunit;

namespace Testes
{
    public class CursoTest
    {
        private Curso CursoValido() => new Curso("Nome", "descrição", 20, 20000M);
        private Estudante EstudanteValido() => new Estudante("Gabriel", "Nascimento", DateTime.Now);
        [Fact]
        public void CriaCursoValido()
        {
            var curso = CursoValido();
            Assert.True(curso.IsValid);
        }
        [Fact]
        public void CriaCursoInvalidoNome()
        {
            var curso = new Curso("", "Descrição", 21, 2000M);
            Assert.False(curso.IsValid);
        }
        [Fact]
        public void CriaCursoPrecoInvalido()
        {
            var curso = new Curso("teste", "teste", 20, -50M);
            Assert.False(curso.IsValid);
        }
        [Fact]
        public void CriaCursoDuracaoInvalido()
        {
            var curso = new Curso("teste", "teste", -20, 50M);
            Assert.False(curso.IsValid);
        }
        [Fact]
        public void AdicionaEstudanteValidoCurso()
        {
            var curso = CursoValido();
            var estudante = EstudanteValido();
            curso.AdicionaEstudanteCurso(estudante);
            Assert.True(curso.IsValid && curso.Estudantes?.Count > 0);
        }
        [Fact]
        public void AdicionaEstudanteInvalidoCurso()
        {
            var curso = CursoValido();
            var estudante = new Estudante("", "23", DateTime.Now);
            curso.AdicionaEstudanteCurso(estudante);
            Assert.True(curso.IsValid && (curso.Estudantes is null || curso.Estudantes.Count == 0));
        }
        [Fact]
        public void RemoveEstudanteValido()
        {
            var curso = CursoValido();
            var estudante = EstudanteValido();
            curso.AdicionaEstudanteCurso(estudante);
            curso.RemoveEstudanteCurso(estudante);
            Assert.True(curso.IsValid && estudante.IsValid && curso.Estudantes?.Count == 0);
        }

    }
}
