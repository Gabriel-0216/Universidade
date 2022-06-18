﻿// <auto-generated />
using System;
using Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestrutura.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220618161443_alteracaoCOlunatelefone")]
    partial class alteracaoCOlunatelefone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Dominio.Entidades.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("BIT")
                        .HasColumnName("Ativo");

                    b.Property<int?>("CursoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataCriacao");

                    b.Property<int?>("EstudanteId")
                        .HasColumnType("int");

                    b.Property<bool>("Quitado")
                        .HasColumnType("BIT")
                        .HasColumnName("Quitado");

                    b.Property<string>("UsuarioEditor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UsuarioAuditoria");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("EstudanteId");

                    b.ToTable("[Contrato]", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Descricao");

                    b.Property<int>("DuracaoMeses")
                        .HasColumnType("INT")
                        .HasColumnName("DuracaoMeses");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("UsuarioEditor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UsuarioAuditoria");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("ValorTotal");

                    b.HasKey("Id");

                    b.ToTable("[Curso]", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Estudante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataCriacao");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATETIME")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Sobrenome");

                    b.Property<string>("UsuarioEditor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UsuarioAuditoria");

                    b.HasKey("Id");

                    b.ToTable("[Estudante]", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.ObjetosValor.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Cidade");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("Estado")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Estado");

                    b.Property<int?>("EstudanteId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Numero");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Rua");

                    b.Property<string>("UsuarioEditor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UsuarioAuditoria");

                    b.HasKey("Id");

                    b.HasIndex("EstudanteId");

                    b.ToTable("[Endereco]", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.ObjetosValor.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataCriacao");

                    b.Property<int>("Ddd")
                        .HasColumnType("int")
                        .HasColumnName("DDD");

                    b.Property<int?>("EstudanteId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Numero");

                    b.Property<string>("UsuarioEditor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UsuarioAuditoria");

                    b.HasKey("Id");

                    b.HasIndex("EstudanteId");

                    b.ToTable("[Telefone]", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("UsuarioEditor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UsuarioAuditoria");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("ValorTotal");

                    b.HasKey("Id");

                    b.ToTable("[Pagamento]", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ContratoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataCriacao");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("DATETIME")
                        .HasColumnName("DataVencimento");

                    b.Property<int>("Numero")
                        .HasColumnType("INT")
                        .HasColumnName("Numero");

                    b.Property<int?>("PagamentoId")
                        .HasColumnType("int");

                    b.Property<bool>("Pago")
                        .HasColumnType("BIT")
                        .HasColumnName("Pago");

                    b.Property<string>("UsuarioEditor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UsuarioAuditoria");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ContratoId");

                    b.HasIndex("PagamentoId");

                    b.ToTable("[Parcelas]", (string)null);
                });

            modelBuilder.Entity("EstudanteCurso", b =>
                {
                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<int>("EstudanteId")
                        .HasColumnType("int");

                    b.HasKey("CursoId", "EstudanteId");

                    b.HasIndex("EstudanteId");

                    b.ToTable("EstudanteCurso");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Contrato", b =>
                {
                    b.HasOne("Dominio.Entidades.Curso", "Curso")
                        .WithMany("Contratos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Dominio.Entidades.Estudante", "Estudante")
                        .WithMany("Contratos")
                        .HasForeignKey("EstudanteId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Curso");

                    b.Navigation("Estudante");
                });

            modelBuilder.Entity("Dominio.Entidades.ObjetosValor.Endereco", b =>
                {
                    b.HasOne("Dominio.Entidades.Estudante", "Estudante")
                        .WithMany("Enderecos")
                        .HasForeignKey("EstudanteId");

                    b.Navigation("Estudante");
                });

            modelBuilder.Entity("Dominio.Entidades.ObjetosValor.Telefone", b =>
                {
                    b.HasOne("Dominio.Entidades.Estudante", "Estudante")
                        .WithMany("Telefones")
                        .HasForeignKey("EstudanteId");

                    b.Navigation("Estudante");
                });

            modelBuilder.Entity("Dominio.Entidades.Parcela", b =>
                {
                    b.HasOne("Dominio.Entidades.Contrato", "Contrato")
                        .WithMany("Parcelas")
                        .HasForeignKey("ContratoId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Dominio.Entidades.Pagamento", "Pagamento")
                        .WithMany("Parcelas")
                        .HasForeignKey("PagamentoId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Contrato");

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("EstudanteCurso", b =>
                {
                    b.HasOne("Dominio.Entidades.Curso", null)
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_EstudanteCurso_CursoId");

                    b.HasOne("Dominio.Entidades.Estudante", null)
                        .WithMany()
                        .HasForeignKey("EstudanteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_EstudanteCurso_EstudanteId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Contrato", b =>
                {
                    b.Navigation("Parcelas");
                });

            modelBuilder.Entity("Dominio.Entidades.Curso", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Dominio.Entidades.Estudante", b =>
                {
                    b.Navigation("Contratos");

                    b.Navigation("Enderecos");

                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("Dominio.Entidades.Pagamento", b =>
                {
                    b.Navigation("Parcelas");
                });
#pragma warning restore 612, 618
        }
    }
}
