namespace Application.Commands;

public class Response
{
    public void AdicionaErro(string mensagem)
    {
        Erros.Add(new Erro(mensagem));
    }

    public bool OperacaoSucesso() => Erros.Count == 0;
    public IList<Erro> Erros { get; private set; } = new List<Erro>();

    public record Erro(string Descricao);
}