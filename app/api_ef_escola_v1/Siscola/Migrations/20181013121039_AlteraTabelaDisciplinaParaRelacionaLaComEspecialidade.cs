using Microsoft.EntityFrameworkCore.Migrations;

namespace Siscola.Migrations
{
    public partial class AlteraTabelaDisciplinaParaRelacionaLaComEspecialidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecialidadeId",
                table: "Disciplina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_EspecialidadeId",
                table: "Disciplina",
                column: "EspecialidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Especialidade_EspecialidadeId",
                table: "Disciplina",
                column: "EspecialidadeId",
                principalTable: "Especialidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Especialidade_EspecialidadeId",
                table: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_EspecialidadeId",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "EspecialidadeId",
                table: "Disciplina");
        }
    }
}
