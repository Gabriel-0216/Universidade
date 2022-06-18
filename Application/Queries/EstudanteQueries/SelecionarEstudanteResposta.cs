using Application.Dtos;

namespace Application.Queries.EstudanteQueries;

public class SelecionarEstudanteResposta
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public IList<EnderecoDto>? Enderecos { get; set; }
    public IList<TelefoneDto>? Telefones { get; set; }

    public SelecionarEstudanteResposta(int id, string nome, string sobrenome)
    {
        Id = id;
        Nome = nome;
        Sobrenome = sobrenome;
    }

    public void AdicionarEndereco(EnderecoDto endereco)
    {
        Enderecos ??= new List<EnderecoDto>();
        Enderecos.Add(endereco);
    }

    public void AdicionaTelefone(TelefoneDto telefone)
    {
        Telefones ??= new List<TelefoneDto>();
        Telefones.Add(telefone);
    }
}