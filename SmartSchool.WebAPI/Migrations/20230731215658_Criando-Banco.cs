using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchool.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    DataNasc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataIni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    DataIni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCuros",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataIni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCuros", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCuros_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCuros_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CargaHoraria = table.Column<int>(type: "INTEGER", nullable: false),
                    PrerequisitoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataIni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Nota = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7058), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" },
                    { 2, true, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7069), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" },
                    { 3, true, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7074), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" },
                    { 4, true, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7079), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" },
                    { 5, true, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7085), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" },
                    { 6, true, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7091), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" },
                    { 7, true, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7096), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(6813), "Lauro", 1, "Oliveira" },
                    { 2, true, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(6830), "Roberto", 2, "Soares" },
                    { 3, true, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(6831), "Ronaldo", 3, "Marconi" },
                    { 4, true, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(6832), "Rodrigo", 4, "Carvalho" },
                    { 5, true, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(6833), "Alexandre", 5, "Montanha" }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 3, "Matemática", null, 1 },
                    { 3, 0, 3, "Física", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Inglês", null, 4 },
                    { 6, 0, 2, "Inglês", null, 4 },
                    { 7, 0, 3, "Inglês", null, 4 },
                    { 8, 0, 1, "Programação", null, 5 },
                    { 9, 0, 2, "Programação", null, 5 },
                    { 10, 0, 3, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7123), null },
                    { 1, 4, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7126), null },
                    { 1, 5, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7127), null },
                    { 2, 1, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7128), null },
                    { 2, 2, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7129), null },
                    { 2, 5, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7131), null },
                    { 3, 1, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7132), null },
                    { 3, 2, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7133), null },
                    { 3, 3, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7134), null },
                    { 4, 1, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7136), null },
                    { 4, 4, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7137), null },
                    { 4, 5, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7138), null },
                    { 5, 4, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7139), null },
                    { 5, 5, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7140), null },
                    { 6, 1, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7141), null },
                    { 6, 2, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7142), null },
                    { 6, 3, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7143), null },
                    { 6, 4, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7189), null },
                    { 7, 1, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7190), null },
                    { 7, 2, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7191), null },
                    { 7, 3, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7192), null },
                    { 7, 4, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7193), null },
                    { 7, 5, null, new DateTime(2023, 7, 31, 18, 56, 58, 219, DateTimeKind.Local).AddTicks(7194), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCuros_CursoId",
                table: "AlunosCuros",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCuros");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
