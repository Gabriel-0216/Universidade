using Application.Dtos;
using Dominio.Entidades;
using Infraestrutura.Repositorios.ContratoRepositorio;
using Infraestrutura.Repositorios.CursoRepositorio;
using Infraestrutura.Repositorios.EstudanteRepositorio;
using MediatR;

namespace Application.Commands.ContratoCommands;

public class GerarContratoHandler : IRequestHandler<GerarContratoCommand, GerarContratoResponse>
{
    private readonly IEstudanteRepositorio _estudanteRepositorio;
    private readonly ICursoRepositorio _cursoRepositorio;
    private readonly IContratoRepositorio _contratoRepositorio;

    public GerarContratoHandler(IEstudanteRepositorio estudanteRepositorio, ICursoRepositorio cursoRepositorio, IContratoRepositorio contratoRepositorio)
    {
        _estudanteRepositorio = estudanteRepositorio;
        _cursoRepositorio = cursoRepositorio;
        _contratoRepositorio = contratoRepositorio;
    }

    public async Task<GerarContratoResponse> Handle(GerarContratoCommand request, CancellationToken cancellationToken)
    {
        var resposta = new GerarContratoResponse();
        try
        {
            var estudante = await _estudanteRepositorio.SelecionarPorId(request.EstudanteId);
            var curso = await _cursoRepositorio.SelecionarPorId(request.CursoId);
            if(estudante is null || curso is null)
                resposta.AdicionaErro("Estudante não cadastrado.");
            if(curso is null)
                resposta.AdicionaErro("Curso não cadastrado.");
            if(request.QuantidadeParcelas < 1)
                resposta.AdicionaErro("A quantidade mínima de parcelas é 1.");

            if (resposta.Erros.Any()) return resposta;

            var contrato = new Contrato();
            contrato.GerarContrato(curso!, estudante!, request.QuantidadeParcelas);
            if(!contrato.IsValid)
                foreach(var item in contrato.Notifications)
                    resposta.AdicionaErro($"{item.Key}, {item.Message}");

            if (resposta.Erros.Any()) return resposta;

            var inserirContratoBanco = await _contratoRepositorio.Adicionar(contrato);
            if (!inserirContratoBanco)
            {
                resposta.AdicionaErro("A aplicação conseguiu gerar o contrato mas não foi possível adicionar no banco de dados.");
                return resposta;
            }
            
            resposta.FinalizarOperacao(request.EstudanteId, request.CursoId, contrato.Id, contrato.Ativo);
            foreach(var item in contrato.Parcelas!)
                resposta.AdicionaParcela(new ParcelaDto()
                    {DataVencimento = item.DataVencimento, NumeroParcela = item.Numero, Valor = item.Valor});

            return resposta;

        }
        catch (Exception ex)
        {
            resposta.AdicionaErro(ex.Message);
            return resposta;
        }
    }
}