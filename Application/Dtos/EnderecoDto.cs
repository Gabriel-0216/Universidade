namespace Application.Dtos;

public class EnderecoDto
{
    public string Cep { get; set; } = string.Empty;
    public string Rua { get; set; } = string.Empty;
    public string? Cidade { get; set; } = string.Empty;
    public string? Estado { get; set; } = string.Empty;
    public string? Numero { get; set; } = string.Empty;

    public EnderecoDto()
    {
        
    }

    public EnderecoDto(string cep, string rua, string? cidade, string? estado, string? numero)
    {
        Cep = cep;
        Rua = rua;
        Cidade = cidade;
        Estado = estado;
        Numero = numero;

    }
}