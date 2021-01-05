using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAspCap1.Migrations
{
    public partial class SeedProfessoresCurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoID", "DepartamentoID", "Nome" },
                values: new object[,]
                {
                    { 1L, null, "Leituras Práticas" },
                    { 2L, null, "Meditações" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "ProfessorID", "Nome" },
                values: new object[,]
                {
                    { 1L, "Carlos Pedrinho" },
                    { 2L, "João Silva" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Professores",
                keyColumn: "ProfessorID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Professores",
                keyColumn: "ProfessorID",
                keyValue: 2L);
        }
    }
}
