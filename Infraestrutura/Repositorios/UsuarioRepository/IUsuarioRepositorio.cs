namespace Infraestrutura.Repositorios.UsuarioRepository;

public interface IUsuarioRepositorio
{
    Task<bool> Cadastrar();
}