using Application.Queries.EstudanteQueries;
using WebApp.ViewModels;
using WebApp.ViewModels.CursoViewModel;
using WebApp.ViewModels.EstudanteViewModel;

namespace WebApp.Mapeamentos;

public static class EstudanteMapper
{
    public static IList<EstudanteVm> MapearEstudantesVm(IList<SelecionarEstudanteResposta> estudantes)
    {
        var listaEstudantesViewModel = new List<EstudanteVm>();
        foreach (var item in estudantes)
        {
            var estudante = new EstudanteVm()
            {
                Id = item.Id,
                Nome = item.Nome,
                Sobrenome = item.Sobrenome,
                DataNascimento = item.DataNascimento
            };
            if(item.Telefones is not null)
                foreach (var telefone in item.Telefones)
                    estudante.Telefones.Add(new TelefoneVm(telefone.Ddd, telefone.Numero));
                    
            listaEstudantesViewModel.Add(estudante);
        }
        return listaEstudantesViewModel;
    }

    public static EstudanteVm MapearEstudanteVm(SelecionarEstudanteResposta estudante)
    {
        var estudanteVm =
            new EstudanteVm(estudante.Id, estudante.Nome, estudante.Sobrenome, estudante.DataNascimento);

        if (estudante.Telefones is not null)
            foreach(var item in estudante.Telefones)
                estudanteVm.Telefones.Add(new TelefoneVm(item.Ddd, item.Numero));

        if (estudante.Cursos is null) return estudanteVm;
        foreach(var curso in estudante.Cursos)
            estudanteVm.Cursos.Add(new CursoVm(curso.Id, curso.Nome, curso.Descricao, curso.DuracaoMeses, curso.ValorTotal));
                
        return estudanteVm;
    }
}