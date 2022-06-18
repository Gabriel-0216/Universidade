namespace Application.Queries;

public class RespostaGenerica
{
    public bool Sucesso { get; set; }
    public IList<Erro> Erros { get; set; } = new List<Erro>();

    public void AdicionaErro(string erro) => Erros.Add(new Erro(erro));
    public record Erro(string Descricao);
}