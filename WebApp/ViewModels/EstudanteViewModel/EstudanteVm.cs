using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.EstudanteViewModel;

public class EstudanteVm
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo é obrigatório")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O tamanho mínimo do campo é 1 e o máximo é 100")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo é obrigatório")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O tamanho mínimo do campo é 1 e o máximo é 100")]
    public string Sobrenome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo é obrigatório")]
    [DataType(DataType.DateTime, ErrorMessage = "O campo deve ser uma data válida")]
    public DateTime DataNascimento { get; set; }

    public IList<TelefoneVm> Telefones { get; set; } = new List<TelefoneVm>();
    
}