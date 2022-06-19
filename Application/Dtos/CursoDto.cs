namespace Application.Dtos;

public class CursoDto
{
    public int Id { get; set; }
    public string Nome { get; private set; } = string.Empty;
    public string Descricao { get; private set; } = string.Empty;
    public int DuracaoMeses { get; private set; }
    public decimal ValorTotal { get; private set; }

    public CursoDto()
    {
        
    }

    public CursoDto(int id, string nome, string descricao, int duracaoMeses, decimal valorTotal)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        DuracaoMeses = duracaoMeses;
        ValorTotal = valorTotal;
    }
}