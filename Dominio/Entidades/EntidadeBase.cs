using Flunt.Notifications;

namespace Dominio.Entidades
{
    public class EntidadeBase : Notifiable<Notification>
    {
        public int Id { get; set; } = 0;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
        public string UsuarioEditor { get; set; } = string.Empty;
    }
}
