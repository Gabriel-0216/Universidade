using System.ComponentModel.DataAnnotations;
using WebApp.ViewModels.EstudanteViewModel;

namespace WebApp.ViewModels.ContratoViewModel;

public class GerarContratoVm
{
    [Required(ErrorMessage = "Obrigatório")]
    public int EstudanteId { get; set; }
    public EstudanteVm? Estudante { get; set; }
    [Required(ErrorMessage = "Obrigatório")]
    public int CursoId { get; set; }
    [Required(ErrorMessage = "Obrigatório")]
    public int QuantidadeParcelas { get; set; }

    public GerarContratoVm()
    {
        
    }

    public GerarContratoVm(int estudanteId, EstudanteVm estudante)
    {
        Estudante = estudante;
        EstudanteId = estudanteId;
    }
}