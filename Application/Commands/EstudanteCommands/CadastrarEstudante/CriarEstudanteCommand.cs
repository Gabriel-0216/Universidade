using Application.Dtos;
using Application.Dtos;
using MediatR;

namespace Application.Commands.EstudanteCommands.CadastrarEstudante;

public class CriarEstudanteCommand : IRequest<CriarEstudanteResponse>
{
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }

    public IList<EnderecoDto>? Enderecos { get; set; }
    public IList<TelefoneDto> Telefones { get; set; } = new List<TelefoneDto>();
}