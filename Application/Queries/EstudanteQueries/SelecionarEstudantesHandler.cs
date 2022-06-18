using Application.Dtos;
using Dominio.Entidades;
using Infraestrutura.Repositorios.EstudanteRepositorio;
using MediatR;

namespace Application.Queries.EstudanteQueries;

public class SelecionarEstudantesHandler : IRequestHandler<SelecionarEstudantesQuery, IList<SelecionarEstudanteResposta>>
{
    private readonly IEstudanteRepositorio _estudanteRepositorio;

    public SelecionarEstudantesHandler(IEstudanteRepositorio estudanteRepositorio)
    {
        _estudanteRepositorio = estudanteRepositorio;
    }

    public async Task<IList<SelecionarEstudanteResposta>> Handle(SelecionarEstudantesQuery request, CancellationToken cancellationToken)
    {
        var estudantes = await _estudanteRepositorio.SelecionarTodos(request.Skip, request.Take,
            request.IncluirEnderecos, request.IncluirTelefone);
        return MapearEntidades(estudantes);
    }

    private IList<SelecionarEstudanteResposta> MapearEntidades(IEnumerable<Estudante> estudantes)
    {
        var listaEstudantes = new List<SelecionarEstudanteResposta>();
        foreach (var estudante in estudantes)
        {
            var estudanteMapeado = new SelecionarEstudanteResposta(estudante.Id, estudante.Nome, estudante.Sobrenome);
            if(estudante.Telefones is not null)
                foreach (var telefone in estudante.Telefones)
                    estudanteMapeado.AdicionaTelefone(new TelefoneDto(telefone.Ddd, telefone.Numero));
            if (estudante.Enderecos is not null)
                foreach(var endereco in estudante.Enderecos)
                    estudanteMapeado.AdicionarEndereco(new EnderecoDto(endereco.Cep, endereco.Rua, endereco.Cep, endereco.Estado, endereco.Numero));
            
            listaEstudantes.Add(estudanteMapeado);

        }
        return listaEstudantes;
    }
}