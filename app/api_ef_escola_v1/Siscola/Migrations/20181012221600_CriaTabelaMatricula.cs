using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Siscola.Migrations
{
    public partial class CriaTabelaMatricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataDaMatricula = table.Column<DateTime>(nullable: false),
                    RA = table.Column<string>(maxLength: 16, nullable: false),
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matricula_PessoaFisica_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matricula_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AlunoId",
                table: "Matricula",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_CursoId",
                table: "Matricula",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matricula");
        }
    }
}
