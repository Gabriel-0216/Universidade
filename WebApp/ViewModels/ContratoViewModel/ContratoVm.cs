using System.ComponentModel.DataAnnotations;
using WebApp.ViewModels.CursoViewModel;
using WebApp.ViewModels.EstudanteViewModel;

namespace WebApp.ViewModels.ContratoViewModel;

public class ContratoVm
{
    public int Id { get; set; }
    public bool Ativo { get; set; }
    public bool Quitado { get; set; }
    [Display(Name = "Data geração")]
    public DateTime DataGeracao { get; set; }
    [Display(Name = "Data atualização")]
    public DateTime DataAtualizacao { get; set; }
    [Display(Name = "Usuário cadastro")]
    public string UsuarioAuditoria { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo obrigatório")]
    public int EstudanteId { get; set; }
    public EstudanteVm? Estudante { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public int CursoId { get; set; }
    public CursoVm? Curso { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public int QuantidadeParcelas { get; set; }

    public IList<ParcelaVm> Parcelas { get; set; } = new List<ParcelaVm>();

    public ContratoVm()
    {
        
    }

    public ContratoVm(int id, bool ativo, bool quitado, DateTime dataGeracao,
        DateTime dataAtualizacao, string usuarioAuditoria)
    {
        Id = id;
        Ativo = ativo;
        Quitado = quitado;
        DataGeracao = dataGeracao;
        DataAtualizacao = dataAtualizacao;
        UsuarioAuditoria = usuarioAuditoria;
    }
    public ContratoVm(int id, bool ativo, bool quitado, DateTime dataGeracao,
        DateTime dataAtualizacao, string usuarioAuditoria, IList<ParcelaVm> parcelas)
    {
        Id = id;
        Ativo = ativo;
        Quitado = quitado;
        DataGeracao = dataGeracao;
        DataAtualizacao = dataAtualizacao;
        UsuarioAuditoria = usuarioAuditoria;
        Parcelas = parcelas;
    }

    public ContratoVm(EstudanteVm estudante, CursoVm curso, int quantidadeParcelas)
    {
        Estudante = estudante;
        EstudanteId = estudante.Id;
        Curso = curso;
        CursoId = curso.Id;
        QuantidadeParcelas = quantidadeParcelas;
    }

    public void AdicionaParcela(ParcelaVm parcela)
    {
        Parcelas.Add(parcela);
    }


}