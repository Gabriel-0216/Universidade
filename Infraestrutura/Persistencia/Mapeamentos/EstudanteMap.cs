using Dominio.Entidades;
using Dominio.Entidades.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Persistencia.Mapeamentos;

public class EstudanteMap : IEntityTypeConfiguration<Estudante>
{
    public void Configure(EntityTypeBuilder<Estudante> builder)
    {
        builder.ToTable("[Estudante]");
        
        builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        builder.Property(p => p.Nome)
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnName("Nome")
            .IsRequired();
        
        builder.Property(p => p.Sobrenome)
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnName("Sobrenome")
            .IsRequired();

        builder.Property(p => p.DataNascimento)
            .HasColumnName("DataNascimento")
            .HasColumnType("DATETIME")
            .IsRequired();

        builder
            .HasMany<Endereco>(p => p.Enderecos)
            .WithOne(p=> p.Estudante);

        builder.HasMany<Telefone>(p => p.Telefones)
            .WithOne(p => p.Estudante);

        builder.HasMany<Contrato>(p => p.Contratos)
            .WithOne(p => p.Estudante)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.Cursos)
            .WithMany(p => p.Estudantes)
            .UsingEntity<Dictionary<string, object>>("EstudanteCurso",
                curso => curso.HasOne<Curso>()
                    .WithMany()
                    .HasForeignKey("CursoId")
                    .HasConstraintName("FK_EstudanteCurso_CursoId")
                    .OnDelete(DeleteBehavior.NoAction),
                estudante => estudante.HasOne<Estudante>()
                    .WithMany()
                    .HasForeignKey("EstudanteId")
                    .HasConstraintName("FK_EstudanteCurso_EstudanteId")
                    .OnDelete(DeleteBehavior.NoAction));
        
        
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