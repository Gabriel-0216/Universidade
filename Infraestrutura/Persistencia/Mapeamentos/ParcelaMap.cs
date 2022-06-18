using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Persistencia.Mapeamentos;

public class ParcelaMap : IEntityTypeConfiguration<Parcela>
{
    public void Configure(EntityTypeBuilder<Parcela> builder)
    {
        builder.ToTable("[Parcelas]");
        builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        builder.Property(p => p.Numero)
            .HasColumnType("INT")
            .HasColumnName("Numero")
            .IsRequired();
        builder.HasOne<Contrato>(p => p.Contrato)
            .WithMany(p => p.Parcelas)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Valor)
            .IsRequired()
            .HasColumnType("decimal(5,2)")
            .HasColumnName("Valor");

        builder.Property(p => p.DataVencimento)
            .IsRequired()
            .HasColumnType("DATETIME")
            .HasColumnName("DataVencimento");

        builder.HasOne<Pagamento>(p => p.Pagamento)
            .WithMany(p => p.Parcelas)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Pago)
            .HasColumnType("BIT")
            .HasColumnName("Pago")
            .IsRequired();
        
        builder.Property(p => p.DataCriacao)
            .HasColumnName("DataCriacao")
            .HasColumnType("Datetime")
            .IsRequired();
        builder.Property(p => p.DataAtualizacao)
            .HasColumnName("DataAtualizacao")
            .HasColumnType("Datetime");

        builder.Property(p => p.UsuarioEditor)
            .HasColumnName("UsuarioAuditoria")
            .HasColumnType("nvarchar")
            .HasMaxLength(50);
        
        builder.Ignore(p => p.Notifications);
        builder.Ignore(p => p.IsValid);

    }
}