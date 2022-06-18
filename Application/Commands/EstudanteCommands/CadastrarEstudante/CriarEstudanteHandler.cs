using Application.Dtos;
using Dominio.Entidades;
using Dominio.Entidades.ObjetosValor;
using Infraestrutura.Repositorios.EstudanteRepositorio;
using MediatR;

namespace Application.Commands.EstudanteCommands.CadastrarEstudante;

public class CriarEstudanteHandler : IRequestHandler<CriarEstudanteCommand, CriarEstudanteResponse>
{
    private readonly IEstudanteRepositorio _estudanteRepositorio;

    public CriarEstudanteHandler(IEstudanteRepositorio estudanteRepositorio)
    {
        _estudanteRepositorio = estudanteRepositorio;
    }

    public async Task<CriarEstudanteResponse> Handle(CriarEstudanteCommand request, CancellationToken cancellationToken)
    {
        var resposta = new CriarEstudanteResponse();
        try
        {
            var estudante = new Estudante(request.Nome, request.Sobrenome, request.DataNascimento);
            if(request.Enderecos is not null) AdicionarEnderecos(request.Enderecos, estudante);
            AdicionarTelefones(request.Telefones, estudante);

            if (!estudante.IsValid)
            {
                foreach (var item in estudante.Notifications)
                {
                    resposta.AdicionaErro($"{item.Key}, {item.Message}");
                }
                return resposta;
            }

            var adicionadoSucesso = await _estudanteRepositorio.Adicionar(estudante);
            if (adicionadoSucesso)
            {
                resposta.Sucesso(estudante.Id, estudante.Nome, estudante.Sobrenome);
                return resposta;
            }
            resposta.AdicionaErro("Ocorreu um erro interno no servidor ao adicionar");
            return resposta;


        }
        catch (Exception ex)
        {
            resposta.AdicionaErro(ex.Message);
            return resposta;
        }
    }

    private void AdicionarEnderecos(IEnumerable<EnderecoDto> enderecos, Estudante estudante)
    {
        foreach (var item in enderecos)
        {
            estudante.AdicionaEndereco(new Endereco(item.Cep, item.Rua, item.Cidade, item.Estado, item.Numero));
        }
    }

    private void AdicionarTelefones(IEnumerable<TelefoneDto> telefones, Estudante estudante)
    {
        foreach (var item in telefones)
        {
            estudante.AdicionaTelefone(new Telefone(item.Ddd, item.Numero));
        }
    }
}