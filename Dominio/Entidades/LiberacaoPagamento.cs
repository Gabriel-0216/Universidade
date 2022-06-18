using Dominio.Genericos;

namespace Dominio.Entidades
{
    public class LiberacaoPagamento : EntidadeBase
    {
        public string UsuarioLiberacao { get; set; } = string.Empty;
        public IList<Parcela>? Parcelas { get; set; }
        public string MotivoLiberacao { get; set; } = string.Empty;

        public LiberacaoPagamento()
        {
            
        }
        public LiberacaoPagamento(string usuarioLiberacao, string motivoLiberacao, IList<Parcela> parcelas)
        {
            if(parcelas is null)
            {
                AddNotification("Parcelas", "Parcelas é nulo");
            }
            if (string.IsNullOrEmpty(usuarioLiberacao)) AddNotification("Usuário liberação", MensagensValidacoes.PropriedadeObrigatoria);
            if (string.IsNullOrEmpty(motivoLiberacao)) AddNotification("Motivo liberação", MensagensValidacoes.PropriedadeObrigatoria);

            if (IsValid)
            {
                Parcelas = parcelas;
                MotivoLiberacao = motivoLiberacao;
                UsuarioLiberacao = usuarioLiberacao;
            }
        }
    }
}
