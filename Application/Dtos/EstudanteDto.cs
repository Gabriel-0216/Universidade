namespace Application.Dtos;

public class EstudanteDto
{
    public int EstudanteId { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Sobrenome { get; private set; } = string.Empty;

    public EstudanteDto()
    {
        
    }

    public EstudanteDto(int id, string nome, string sobrenome)
    {
        EstudanteId = id;
        Nome = nome;
        Sobrenome = sobrenome;
    }
}