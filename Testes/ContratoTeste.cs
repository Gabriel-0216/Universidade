using Dominio.Entidades;
using System;
using Xunit;

namespace Testes
{
    public class ContratoTeste
    {
        private Curso CursoValido() => new Curso("Nome", "descrição", 20, 20000M);
        private Estudante EstudanteValido() => new Estudante("Gabriel", "Nascimento", DateTime.Now);
       
        [Fact]
        public void CriaContratoValido()
        {
            // Given
            var curso = CursoValido();
            var estudante = EstudanteValido();
            // When
            var contrato = new Contrato();
            contrato.GerarContrato(curso, estudante, 6);
            // Then
            Assert.True(contrato.IsValid && (contrato.Parcelas is not null && contrato.Parcelas.Count == 6));
        }
        [Fact]
        public void CriaContratoInvalido()
        {
            // Given
            var curso = CursoValido();
            var estudante = EstudanteValido();    
            // When
            var contrato = new Contrato();
            contrato.GerarContrato(curso, estudante, 0);
            // Then
            Assert.False(contrato.IsValid && (contrato.Parcelas is null || contrato.Parcelas.Count < 1));
        }
        [Fact]
        public void CriaContratoCursoInvalido()
        {
            var curso = new Curso("", "", 32, 200);
            var estudante = EstudanteValido();
            var contrato = new Contrato();
            contrato.GerarContrato(curso, estudante, 20);
            Assert.False(contrato.IsValid && curso.IsValid);
        }
        [Fact]
        public void CriaContratoEstudanteInvalido()
        {
            var curso = CursoValido();
            var estudante = new Estudante("", "", DateTime.Now);
            var contrato = new Contrato();
            contrato.GerarContrato(curso, estudante, 20);
            Assert.False(contrato.IsValid && estudante.IsValid);
        }
        [Fact]
        public void ContratoValidoSeisParcelas()
        {
            // Given
            var curso = CursoValido();
            var estudante = EstudanteValido();
            // When
            var contrato = new Contrato();
            contrato.GerarContrato(curso, estudante, 6);
            // Then
            Assert.True(contrato.IsValid && (contrato.Parcelas is not null && contrato.Parcelas.Count == 6));
        }
        [Fact]
        public void ContratoValido60Parcelas()
        {
            // Given
            var curso = CursoValido();
            var estudante = EstudanteValido();
            // When
            var contrato = new Contrato();
            contrato.GerarContrato(curso, estudante, 66);
            // Then
            Assert.True(contrato.IsValid && (contrato.Parcelas is not null && contrato.Parcelas.Count == 66));
       
        }
        [Fact]
        public void CriaContratoParcelasNegativas()
        {
            var curso = CursoValido();
            var estudante = EstudanteValido();
            var contrato = new Contrato();
            contrato.GerarContrato(curso, estudante, -1);
            Assert.False(contrato.IsValid);
        }
        [Fact]
        public void ContratoParcelaIgualContrato()
        {
            var curso = CursoValido();
            var estudante = EstudanteValido();
            var contrato = new Contrato();
            contrato.GerarContrato(curso, estudante, 10);
            Assert.True(contrato.IsValid && contrato.Parcelas is not null && contrato.Parcelas[0].Contrato == contrato);
        } 
    }
}