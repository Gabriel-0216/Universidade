using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.EstudanteViewModel;

public class EstudanteVm
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo é obrigatório")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O tamanho mínimo do campo é 1 e o máximo é 100")]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo é obrigatório")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O tamanho mínimo do campo é 1 e o máximo é 100")]
    [Display(Name = "Sobrenome")]
    public string Sobrenome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo é obrigatório")]
    [DataType(DataType.DateTime, ErrorMessage = "O campo deve ser uma data válida")]
    [Display(Name = "Data de nascimento")]
    public DateTime DataNascimento { get; set; }

    public IList<TelefoneVm> Telefones { get; set; } = new List<TelefoneVm>();

    public EstudanteVm()
    {
        
    }

    public EstudanteVm(int id, string nome, string sobrenome, DateTime dataNascimento)
    {
        Id = id;
        Nome = nome;
        Sobrenome = sobrenome;
        DataNascimento = dataNascimento;
    }
    
}