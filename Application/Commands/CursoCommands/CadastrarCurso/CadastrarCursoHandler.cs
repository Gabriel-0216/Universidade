using Dominio.Entidades;
using Infraestrutura.Repositorios.CursoRepositorio;
using MediatR;

namespace Application.Commands.CursoCommands.CadastrarCurso;

public class CadastrarCursoHandler : IRequestHandler<CadastrarCursoCommand, CadastrarCursoResponse>
{
    private readonly ICursoRepositorio _cursoRepositorio;

    public CadastrarCursoHandler(ICursoRepositorio cursoRepositorio)
    {
        _cursoRepositorio = cursoRepositorio;
    }

    public async Task<CadastrarCursoResponse> Handle(CadastrarCursoCommand request, CancellationToken cancellationToken)
    {
        var resposta = new CadastrarCursoResponse();
        try
        {
            var curso = new Curso(request.Curso.Nome, request.Curso.Descricao, request.Curso.DuracaoMeses,
                request.Curso.ValorTotal);
            if (!curso.IsValid)
            {
                foreach(var item in curso.Notifications)
                    resposta.AdicionaErro($"{item.Key}, {item.Message}");

                return resposta;
            }

            var adicionado = await _cursoRepositorio.Adicionar(curso);
            if (adicionado)
            {
                resposta.SetarId(curso.Id);
                return resposta;
            }
            resposta.AdicionaErro("Ocorreu um erro ao salvar o curso");
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.AdicionaErro(ex.Message);
            return resposta;
        }
    }
}