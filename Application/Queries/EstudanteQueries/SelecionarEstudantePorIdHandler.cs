using Application.Dtos;
using Dominio.Entidades;
using Infraestrutura.Repositorios.EstudanteRepositorio;
using MediatR;

namespace Application.Queries.EstudanteQueries;

public class SelecionarEstudantePorIdHandler : IRequestHandler<SelecionarEstudantePorIdQuery, SelecionarEstudanteResposta>
{
    private readonly IEstudanteRepositorio _estudanteRepositorio;

    public SelecionarEstudantePorIdHandler(IEstudanteRepositorio estudanteRepositorio)
    {
        _estudanteRepositorio = estudanteRepositorio;
    }

    public async Task<SelecionarEstudanteResposta> Handle(SelecionarEstudantePorIdQuery request, CancellationToken cancellationToken)
    {
        var estudante = await _estudanteRepositorio.SelecionarEstudantePorId(request.Id, request.IncluirEndereco, request.IncluirTelefone,
            request.IncluirContratos, request.IncluirCursos);
        if (estudante is null)
        {
            var resposta = new SelecionarEstudanteResposta();
            resposta.AdicionaErro("Estudante não existe");
            return resposta;
        }

        var mapearEstudante = MapearEstudante(estudante);
        mapearEstudante.Sucesso = true;
        return mapearEstudante;
    }

    private SelecionarEstudanteResposta MapearEstudante(Estudante estudante)
    {
        var estudanteResposta = new SelecionarEstudanteResposta(estudante.Id, estudante.Nome, estudante.Sobrenome,
            estudante.DataNascimento);
        if (estudante.Telefones is not null) 
            foreach(var telefone in estudante.Telefones)
                estudanteResposta.AdicionaTelefone(new TelefoneDto(telefone.Ddd, telefone.Numero));

        if (estudante.Cursos is not null)
            foreach(var curso in estudante.Cursos)
                estudanteResposta
                    .AdicionaCurso(new CursoDto(curso.Id, curso.Nome, curso.Descricao,
                                                curso.DuracaoMeses, curso.ValorTotal));

        if (estudante.Contratos is null) return estudanteResposta;
        foreach (var contrato in estudante.Contratos)
            estudanteResposta.AdicionaContrato(new ContratoDto(contrato.Id, contrato.DataCriacao,
                contrato.DataAtualizacao, contrato.UsuarioEditor, contrato.Ativo, contrato.Quitado));
            
        return estudanteResposta;

    }
}