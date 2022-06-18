using Dominio.Entidades.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Persistencia.Mapeamentos;

public class EnderecoMap : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("[Endereco]");

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(p => p.Cep)
            .HasColumnName("CEP")
            .HasColumnType("nvarchar")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.Rua)
            .HasColumnName("Rua")
            .HasColumnType("nvarchar")
            .HasMaxLength(100);
        
        builder.Property(p => p.Cidade)
            .HasColumnName("Cidade")
            .HasColumnType("nvarchar")
            .HasMaxLength(50);
        
        builder.Property(p => p.Estado)
            .HasColumnName("Estado")
            .HasColumnType("nvarchar")
            .HasMaxLength(50);
        
        builder.Property(p => p.Numero)
            .HasColumnName("Numero")
            .HasColumnType("nvarchar")
            .HasMaxLength(10);
        
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