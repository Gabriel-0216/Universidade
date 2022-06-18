using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.CursoViewModel;

public class CursoVm
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Nome { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Descricao { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public int DuracaoMeses { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
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