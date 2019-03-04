using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioMaster.Infra.Data.Migrations
{
    public partial class CriacaotabelaPessoarelacionamentoImovel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPessoaFinanceiro",
                table: "Imovel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pessoa",
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
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_IdPessoaFinanceiro",
                table: "Imovel",
                column: "IdPessoaFinanceiro");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_CpfCnpj",
                table: "Pessoa",
                column: "CpfCnpj",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Imovel_Pessoa_IdPessoaFinanceiro",
                table: "Imovel",
                column: "IdPessoaFinanceiro",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imovel_Pessoa_IdPessoaFinanceiro",
                table: "Imovel");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Imovel_IdPessoaFinanceiro",
                table: "Imovel");

            migrationBuilder.DropColumn(
                name: "IdPessoaFinanceiro",
                table: "Imovel");
        }
    }
}
