namespace Application.Dtos;

public class ContratoDto
{
    public int Id { get; set; }
    public DateTime DataGeracao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public string UsuarioGerou { get; set; }
    public bool Ativo { get; set; }
    public bool Quitado { get; set; }
    public IList<ParcelaDto> Parcelas { get; set; } = new List<ParcelaDto>();

    public ContratoDto()
    {
        
    }

    public ContratoDto(int id, DateTime dataGeracao, DateTime dataAtualizacao, string usuarioGerou, bool ativo, bool quitado)
    {
        Id = id;
        DataGeracao = dataGeracao;
        DataAtualizacao = dataAtualizacao;
        UsuarioGerou = usuarioGerou;
        Ativo = ativo;
        Quitado = quitado;
    }
}