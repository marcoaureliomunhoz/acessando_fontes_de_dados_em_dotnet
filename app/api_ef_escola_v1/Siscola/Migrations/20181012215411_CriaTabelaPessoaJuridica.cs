using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Siscola.Migrations
{
    public partial class CriaTabelaPessoaJuridica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RazaoSocial = table.Column<string>(maxLength: 100, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 100, nullable: true),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    DataDeAbertura = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaJuridica");
        }
    }
}
