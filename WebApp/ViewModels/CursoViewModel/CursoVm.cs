using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.CursoViewModel;

public class CursoVm
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Nome")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O tamanho mínimo do campo é 1 e o máximo é 100")]
    public string Nome { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Duração em meses")]
    public int DuracaoMeses { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Valor total")]
    public decimal ValorTotal { get; set; }

    public CursoVm()
    {
        
    }

    public CursoVm(int id, string nome, string descricao, int duracaoMeses, decimal valorTotal)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        DuracaoMeses = duracaoMeses;
        ValorTotal = valorTotal;
    }
}