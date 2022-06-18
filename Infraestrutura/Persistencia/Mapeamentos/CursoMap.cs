using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Persistencia.Mapeamentos;

public class CursoMap : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("[Curso]");
        
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(p => p.Nome)
            .HasColumnName("Nome")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Descricao)
            .HasColumnName("Descricao")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(p => p.DuracaoMeses)
            .HasColumnType("INT")
            .HasColumnName("DuracaoMeses")
            .IsRequired();

        builder.Property(p => p.ValorTotal)
            .IsRequired()
            .HasColumnType("decimal(5,2)")
            .HasColumnName("ValorTotal");

        builder.HasMany(p => p.Estudantes)
            .WithMany(p => p.Cursos)
            .UsingEntity<Dictionary<string, object>>("EstudanteCurso",
                estudante => estudante.HasOne<Estudante>()
                    .WithMany()
                    .HasForeignKey("EstudanteId")
                    .HasConstraintName("FK_EstudanteCurso_EstudanteId")
                    .OnDelete(DeleteBehavior.NoAction),
                curso => curso.HasOne<Curso>()
                    .WithMany()
                    .HasForeignKey("CursoId")
                    .HasConstraintName("FK_EstudanteCurso_CursoId")
                    .OnDelete(DeleteBehavior.NoAction));

        builder.HasMany(p => p.Contratos)
            .WithOne(p => p.Curso)
            .OnDelete(DeleteBehavior.NoAction);
        
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