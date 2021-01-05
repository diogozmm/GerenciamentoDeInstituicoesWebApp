using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAspCap1.Migrations
{
    public partial class TProf2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "ProfessorID", "CursoID", "Nome" },
                values: new object[] { 1L, 1L, "Carlos Pedrinho" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "ProfessorID", "CursoID", "Nome" },
                values: new object[] { 2L, 2L, "João Silva" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
