using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes
{
    public class PagamentoTest
    {
        private Curso CursoValido() => new Curso("Nome", "descrição", 20, 20000M);
        private Estudante EstudanteValido() => new Estudante("Gabriel", "Nascimento", DateTime.Now);
        private Contrato ContratoValido()
        {
            var contrato = new Contrato();
            contrato.GerarContrato(CursoValido(), EstudanteValido(), 5);
            return contrato;
        }
        [Fact]
        public void QuitarTodasParcelasValida()
        {
            var contrato = ContratoValido();
            var valorParcelas = contrato.ValorTotalParcelas();
            var pagamento = new Pagamento();

            pagamento.RealizarPagamentoValorExato(valorParcelas, contrato.Parcelas);

            Assert.True(contrato.ContratoQuitado());
        }
        [Fact]
        public void QuitarTodasParcelasValorMenor()
        {
            var contrato = ContratoValido();
            var valorParcelas = contrato.ValorTotalParcelas() - 10;
            var pagamento = new Pagamento();
            pagamento.RealizarPagamentoValorExato(valorParcelas, contrato.Parcelas);

            Assert.False(contrato.ContratoQuitado());
        }
        [Fact]
        public void QuitarMetadeParcelas()
        {
            var contrato = ContratoValido();
            var pagamento = new Pagamento();
            if (contrato.Parcelas is null) return;
            var totalParcelas = contrato.Parcelas.Count();
            var parcelas = contrato.Parcelas.Take(contrato.Parcelas.Count / 2).ToList();
            var valorParcelas = parcelas.Select(p => p.Valor).Sum();
            
            pagamento.RealizarPagamentoValorExato(valorParcelas, parcelas);

            Assert.True((contrato.SelecionarParcelasPagas().Count == parcelas.Count()) && 
                (contrato.SelecionarParcelasAberto().Count == totalParcelas - parcelas.Count()));
        }
        [Fact]
        public void QuitarContrato()
        {
            var contrato = ContratoValido();
            var valorParcelas = contrato.ValorTotalParcelas();
            var pagamento = new Pagamento();
            pagamento.RealizarPagamentoValorExato(valorParcelas, contrato.Parcelas);
            Assert.True(contrato.ContratoQuitado() && contrato.SelecionarParcelasAberto().Count == 0);
        }
        [Fact]
        public void QuitarContratoValorMenor()
        {
            var contrato = ContratoValido();
            var valorParcelas = contrato.ValorTotalParcelas();
            var pagamento = new Pagamento();
            pagamento.RealizarPagamentoValorDistinto(valorParcelas - 100, contrato.Parcelas, "Motivo", "Usuario");
            Assert.True(contrato.ContratoQuitado() && contrato.SelecionarParcelasAberto().Count == 0);
        }
        [Fact]
        public void QuitarContratoValorSuperiorReturnFalse()
        {
            var contrato = ContratoValido();
            var valorParcelas = contrato.ValorTotalParcelas();
            var pagamento = new Pagamento();
            pagamento.RealizarPagamentoValorDistinto(valorParcelas, contrato.Parcelas, "Motivo", "Usuario");
            Assert.False(contrato.ContratoQuitado() && contrato.SelecionarParcelasAberto().Count == 0);
        }
        [Fact]
        public void TentarQuitarContratoInvalido()
        {
            var estudante = EstudanteValido();
            var curso = CursoValido();
            var contrato = new Contrato();
            contrato.GerarContrato(curso, estudante, 6);
            var valorParcelas = contrato.ValorTotalParcelas();
            var pagamento = new Pagamento();
            pagamento.RealizarPagamentoValorExato(valorParcelas, contrato.Parcelas);
            Assert.False(contrato.IsValid && contrato.ContratoQuitado() && contrato.SelecionarParcelasPagas().Count == 0);
        }
        [Fact]
        public void TentarQuitarContratoInvalidoValorMenor()
        {
            var estudante = EstudanteValido();
            var curso = CursoValido();
            var contrato = new Contrato();
            contrato.GerarContrato(curso, estudante, 6);
            var valorParcelas = contrato.ValorTotalParcelas();
            var pagamento = new Pagamento();
            pagamento.RealizarPagamentoValorDistinto(valorParcelas - 100, contrato.Parcelas, "Motivo", "Usuário");
            Assert.False(contrato.IsValid && contrato.ContratoQuitado() && contrato.SelecionarParcelasPagas().Count == 0);
        }
        [Fact]
        public void QuitarParcelasValorDistintoInvalido()
        {
            var contrato = ContratoValido();
            var valorParcelas = contrato.ValorTotalParcelas();
            var pagamento = new Pagamento();
            pagamento.RealizarPagamentoValorDistinto(valorParcelas - 10, contrato.Parcelas, "", "");
            Assert.False(pagamento.IsValid && contrato.ContratoQuitado() && contrato.SelecionarParcelasPagas().Count == 0);
        }
        [Fact]
        public void Contrato_SeisParcelas_Paga3Valido_Paga3Invalido()
        {
            var contrato = ContratoValido();
            var tresParcelasValido = contrato.Parcelas.Take(3).ToList();
            var valorTresParcelas = tresParcelasValido.Select(p => p.Valor).Sum();

            var pagamento = new Pagamento().RealizarPagamentoValorExato(valorTresParcelas, tresParcelasValido);
            var restanteParcelas = contrato.SelecionarParcelasAberto();
            var valorParcelasRestantes = restanteParcelas.Select(p => p.Valor).Sum();
            var segundoPagamento = new Pagamento().RealizarPagamentoValorExato(valorParcelasRestantes - 100, restanteParcelas);

            Assert.True(contrato.IsValid && contrato.SelecionarParcelasPagas().Count == 3 && !contrato.ContratoQuitado());
        }
        [Fact]
        public void Contrato_SeisParcelas_Paga3Valido_Paga3InvalidoDois()
        {
            var contrato = ContratoValido();
            var tresParcelasValido = contrato.Parcelas.Take(3).ToList();
            var valorTresParcelas = tresParcelasValido.Select(p => p.Valor).Sum();

            var pagamento = new Pagamento().RealizarPagamentoValorExato(valorTresParcelas, tresParcelasValido);
            var restanteParcelas = contrato.SelecionarParcelasAberto();
            var valorParcelasRestantes = restanteParcelas.Select(p => p.Valor).Sum();
            var segundoPagamento = new Pagamento().RealizarPagamentoValorDistinto(valorParcelasRestantes, restanteParcelas, "", "");

            Assert.True(contrato.IsValid && contrato.SelecionarParcelasPagas().Count == 3 && !contrato.ContratoQuitado());
        }

    }
}
