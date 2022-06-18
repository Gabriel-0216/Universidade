namespace Application.Dtos;

public class TelefoneDto
{
    public int Ddd { get; set; }
    public string Numero { get; set; } = string.Empty;

    public TelefoneDto()
    {
        
    }

    public TelefoneDto(int ddd, string numero)
    {
        Ddd = ddd;
        Numero = numero;
    }
}