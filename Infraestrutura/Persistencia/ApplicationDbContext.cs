using Dominio.Entidades;
using Dominio.Entidades.ObjetosValor;
using Infraestrutura.Persistencia.Mapeamentos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Persistencia;

public class ApplicationDbContext : IdentityDbContext
{
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder
         .UseSqlServer(@"Server=localhost,1433;Database=University;
                     User ID=sa;Password=1q2w3e4r@#$; TrustServerCertificate=True");
   }

   protected override void OnModelCreating(ModelBuilder builder)
   {
      builder.ApplyConfiguration(new ContratoMap());
      builder.ApplyConfiguration(new CursoMap());
      builder.ApplyConfiguration(new EstudanteMap());
      builder.ApplyConfiguration(new PagamentoMap());
      builder.ApplyConfiguration(new ParcelaMap());
      builder.ApplyConfiguration(new EnderecoMap());
      builder.ApplyConfiguration(new TelefoneMap());
      base.OnModelCreating(builder);
   }

   public DbSet<Contrato>? Contratos { get; set; }
   public DbSet<Curso>? Cursos { get; set; }
   public DbSet<Estudante>? Estudantes { get; set; }
   //public DbSet<LiberacaoPagamento>? LiberacaoPagamentos { get; set; }
   public DbSet<Pagamento>? Pagamentos { get; set; }
   public DbSet<Parcela>? Parcelas { get; set; }
   public DbSet<Endereco>? Enderecos { get; set; }
   public DbSet<Telefone>? Telefones { get; set; } 
   
}