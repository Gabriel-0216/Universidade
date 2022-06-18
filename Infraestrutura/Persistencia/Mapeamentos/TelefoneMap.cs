using Dominio.Entidades.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Persistencia.Mapeamentos;

public class TelefoneMap : IEntityTypeConfiguration<Telefone>
{
    public void Configure(EntityTypeBuilder<Telefone> builder)
    {
        builder.ToTable("[Telefone]");
        
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(p => p.Ddd)
            .HasColumnName("DDD")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Numero)
            .HasColumnName("Numero")
            .HasColumnType("varchar")
            .HasMaxLength(10)
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