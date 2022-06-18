using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class TelefoneVm
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public int Ddd { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Numero { get; set; }
    public TelefoneVm()
    {

    }
    public TelefoneVm(int ddd, string numero)
    {
        Ddd = ddd;
        Numero = numero;
    }
}