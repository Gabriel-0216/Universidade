namespace Application.Commands.EstudanteCommands.CadastrarEstudante;

public class CriarEstudanteResponse : Response
{
    public int Id { get; private set; } = 0;
    public string Nome { get; private set; } = string.Empty;
    public string Sobrenome { get; private set; } = string.Empty;

    public void Sucesso(int id, string nome, string sobrenome)
    {
        Id = id;
        Nome = nome;
        Sobrenome = sobrenome;
    }
}