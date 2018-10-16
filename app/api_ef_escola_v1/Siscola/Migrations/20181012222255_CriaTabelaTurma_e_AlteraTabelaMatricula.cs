using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Siscola.Migrations
{
    public partial class CriaTabelaTurma_e_AlteraTabelaMatricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurmaId",
                table: "Matricula",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Ano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_TurmaId",
                table: "Matricula",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Turma_TurmaId",
                table: "Matricula",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Turma_TurmaId",
                table: "Matricula");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_TurmaId",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Matricula");
        }
    }
}
