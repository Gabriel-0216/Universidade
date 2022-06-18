using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    public partial class ScriptInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "[Curso]",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    DuracaoMeses = table.Column<int>(type: "INT", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_[Curso]", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "[Estudante]",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_[Estudante]", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "[Pagamento]",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_[Pagamento]", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "[Contrato]",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursoId = table.Column<int>(type: "int", nullable: true),
                    EstudanteId = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false),
                    Quitado = table.Column<bool>(type: "BIT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_[Contrato]", x => x.Id);
                    table.ForeignKey(
                        name: "FK_[Contrato]_[Curso]_CursoId",
                        column: x => x.CursoId,
                        principalTable: "[Curso]",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_[Contrato]_[Estudante]_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "[Estudante]",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "[Endereco]",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EstudanteId = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_[Endereco]", x => x.Id);
                    table.ForeignKey(
                        name: "FK_[Endereco]_[Estudante]_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "[Estudante]",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "[Telefone]",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DDD = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "varchar", nullable: false),
                    EstudanteId = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_[Telefone]", x => x.Id);
                    table.ForeignKey(
                        name: "FK_[Telefone]_[Estudante]_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "[Estudante]",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EstudanteCurso",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    EstudanteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudanteCurso", x => new { x.CursoId, x.EstudanteId });
                    table.ForeignKey(
                        name: "FK_EstudanteCurso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "[Curso]",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EstudanteCurso_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "[Estudante]",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "[Parcelas]",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "INT", nullable: false),
                    ContratoId = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PagamentoId = table.Column<int>(type: "int", nullable: true),
                    Pago = table.Column<bool>(type: "BIT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_[Parcelas]", x => x.Id);
                    table.ForeignKey(
                        name: "FK_[Parcelas]_[Contrato]_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "[Contrato]",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_[Parcelas]_[Pagamento]_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "[Pagamento]",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_[Contrato]_CursoId",
                table: "[Contrato]",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_[Contrato]_EstudanteId",
                table: "[Contrato]",
                column: "EstudanteId");

            migrationBuilder.CreateIndex(
                name: "IX_[Endereco]_EstudanteId",
                table: "[Endereco]",
                column: "EstudanteId");

            migrationBuilder.CreateIndex(
                name: "IX_[Parcelas]_ContratoId",
                table: "[Parcelas]",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_[Parcelas]_PagamentoId",
                table: "[Parcelas]",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_[Telefone]_EstudanteId",
                table: "[Telefone]",
                column: "EstudanteId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EstudanteCurso_EstudanteId",
                table: "EstudanteCurso",
                column: "EstudanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "[Endereco]");

            migrationBuilder.DropTable(
                name: "[Parcelas]");

            migrationBuilder.DropTable(
                name: "[Telefone]");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EstudanteCurso");

            migrationBuilder.DropTable(
                name: "[Contrato]");

            migrationBuilder.DropTable(
                name: "[Pagamento]");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "[Curso]");

            migrationBuilder.DropTable(
                name: "[Estudante]");
        }
    }
}
