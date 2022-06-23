using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class UsuarioViewModel
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Obrigatório")]
    public string Email { get; set; }
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string UserName { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Senha obrigatória")]
    public string Password { get; set; }
}