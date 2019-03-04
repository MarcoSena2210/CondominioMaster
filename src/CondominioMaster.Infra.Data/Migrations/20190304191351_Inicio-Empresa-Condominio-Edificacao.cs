using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioMaster.Infra.Data.Migrations
{
    public partial class InicioEmpresaCondominioEdificacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    DataIncluiRegistro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusRegistro = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Apelido = table.Column<string>(type: "varchar(20)", nullable: true),
                    CpfCnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(30)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(30)", nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", nullable: true),
                    CEP = table.Column<string>(type: "varchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condominio",
                columns: table => new
                {
                    DataIncluiRegistro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusRegistro = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Apelido = table.Column<string>(type: "varchar(20)", nullable: true),
                    CpfCnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(30)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(30)", nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", nullable: true),
                    CEP = table.Column<string>(type: "varchar(8)", nullable: true),
                    IdEmpresa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condominio_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Edificacao",
                columns: table => new
                {
                    DataIncluiRegistro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusRegistro = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Apelido = table.Column<string>(type: "varchar(20)", nullable: true),
                    CpfCnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(30)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(30)", nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", nullable: true),
                    CEP = table.Column<string>(type: "varchar(8)", nullable: true),
                    IdCondominio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edificacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edificacao_Condominio_IdCondominio",
                        column: x => x.IdCondominio,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imovel",
                columns: table => new
                {
                    DataIncluiRegistro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusRegistro = table.Column<string>(type: "varchar(10)", nullable: false),
                    NumeroPorta = table.Column<string>(type: "varchar(10)", nullable: false),
                    Identificador = table.Column<string>(type: "varchar(100)", nullable: false),
                    IdEdificacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imovel_Edificacao_IdEdificacao",
                        column: x => x.IdEdificacao,
                        principalTable: "Edificacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Condominio_IdEmpresa",
                table: "Condominio",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Condominio_CpfCnpj",
                table: "Condominio",
                column: "CpfCnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edificacao_IdCondominio",
                table: "Edificacao",
                column: "IdCondominio");

            migrationBuilder.CreateIndex(
                name: "IX_Edificacao_CpfCnpj",
                table: "Edificacao",
                column: "CpfCnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_CpfCnpj",
                table: "Empresa",
                column: "CpfCnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_IdEdificacao",
                table: "Imovel",
                column: "IdEdificacao");

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_Identificador",
                table: "Imovel",
                column: "Identificador",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imovel");

            migrationBuilder.DropTable(
                name: "Edificacao");

            migrationBuilder.DropTable(
                name: "Condominio");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
