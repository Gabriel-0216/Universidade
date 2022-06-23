using Microsoft.AspNetCore.Identity;

namespace WebApp.ViewModels.SuperViewModel;

public class AtribuirFuncaoViewModel
{
    public string UsuarioId { get; set; }
    public string RoleId { get; set; }
    public IList<IdentityRole> Roles { get; set; } = new List<IdentityRole>();

    public AtribuirFuncaoViewModel(string usuarioId)
    {
        UsuarioId = usuarioId;
    }

    public AtribuirFuncaoViewModel()
    {
        
        
    }
}