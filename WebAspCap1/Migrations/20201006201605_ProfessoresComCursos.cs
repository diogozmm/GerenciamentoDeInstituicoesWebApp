using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAspCap1.Migrations
{
    public partial class ProfessoresComCursos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CursoID",
                table: "Professores",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Professores",
                keyColumn: "ProfessorID",
                keyValue: 1L,
                column: "CursoID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Professores",
                keyColumn: "ProfessorID",
                keyValue: 2L,
                column: "CursoID",
                value: 2L);

            migrationBuilder.CreateIndex(
                name: "IX_Professores_CursoID",
                table: "Professores",
                column: "CursoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Cursos_CursoID",
                table: "Professores",
                column: "CursoID",
                principalTable: "Cursos",
                principalColumn: "CursoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Cursos_CursoID",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Professores_CursoID",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "CursoID",
                table: "Professores");
        }
    }
}
