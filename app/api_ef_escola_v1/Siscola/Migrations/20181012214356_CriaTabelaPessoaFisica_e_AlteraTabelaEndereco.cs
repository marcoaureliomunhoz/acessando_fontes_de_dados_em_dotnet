using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Siscola.Migrations
{
    public partial class CriaTabelaPessoaFisica_e_AlteraTabelaEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaFisicaId",
                table: "Endereco",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeCivil = table.Column<string>(maxLength: 100, nullable: false),
                    NomeSocial = table.Column<string>(maxLength: 100, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    RG = table.Column<string>(maxLength: 10, nullable: true),
                    DataDeNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PessoaFisicaId",
                table: "Endereco",
                column: "PessoaFisicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_PessoaFisica_PessoaFisicaId",
                table: "Endereco",
                column: "PessoaFisicaId",
                principalTable: "PessoaFisica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_PessoaFisica_PessoaFisicaId",
                table: "Endereco");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_PessoaFisicaId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "PessoaFisicaId",
                table: "Endereco");
        }
    }
}
