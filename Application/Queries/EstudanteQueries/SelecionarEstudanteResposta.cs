using Application.Dtos;

namespace Application.Queries.EstudanteQueries;

public class SelecionarEstudanteResposta : RespostaGenerica
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; }
    public IList<EnderecoDto>? Enderecos { get; set; }
    public IList<TelefoneDto>? Telefones { get; set; }

    public SelecionarEstudanteResposta(int id, string nome, string sobrenome, DateTime dataNascimento)
    {
        Id = id;
        Nome = nome;
        Sobrenome = sobrenome;
        DataNascimento = dataNascimento;
    }

    public SelecionarEstudanteResposta()
    {
        
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