using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Persistencia.Mapeamentos;

public class ContratoMap : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.ToTable("[Contrato]");

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        builder
            .HasOne<Curso>(p => p.Curso)
            .WithMany(p => p.Contratos)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne<Estudante>(p => p.Estudante)
            .WithMany(p => p.Contratos)            
            .OnDelete(DeleteBehavior.NoAction);


        builder
            .HasMany<Parcela>(p => p.Parcelas)
            .WithOne(p => p.Contrato)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Ativo)
            .HasColumnName("Ativo")
            .HasColumnType("BIT")
            .IsRequired();

        builder.Property(p => p.Quitado)
            .HasColumnName("Quitado")
            .HasColumnType("BIT")
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