using Application.Queries.CursoQueries;
using WebApp.ViewModels.CursoViewModel;

namespace WebApp.Mapeamentos;

public static class CursoMapper
{
    public static IList<CursoVm> MapearCursos(IList<SelecionarCursosResposta> cursos)
    {
        return cursos.Select(item => new CursoVm(item.Id, item.Curso.Nome, item.Curso.Descricao,
            item.Curso.DuracaoMeses, item.Curso.ValorTotal)).ToList();
    }
}