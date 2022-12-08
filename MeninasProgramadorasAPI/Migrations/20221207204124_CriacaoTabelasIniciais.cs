using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeninasProgramadorasAPI.Migrations;

public partial class CriacaoTabelasIniciais : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Alunas",
            columns: table => new
            {
                CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PrimeiroNome = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                NomeCompleto = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Email = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                BeecrowdId = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Alunas", x => x.CPF);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Turmas",
            columns: table => new
            {
                Numero = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                TotalSemanas = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Turmas", x => x.Numero);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Avaliacoes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                AlunaCPF = table.Column<string>(type: "varchar(11)", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TurmaNumero = table.Column<int>(type: "int", nullable: false),
                PresencaAberturaId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                table.ForeignKey(
                    name: "FK_Avaliacoes_Alunas_AlunaCPF",
                    column: x => x.AlunaCPF,
                    principalTable: "Alunas",
                    principalColumn: "CPF");
                table.ForeignKey(
                    name: "FK_Avaliacoes_Turmas_TurmaNumero",
                    column: x => x.TurmaNumero,
                    principalTable: "Turmas",
                    principalColumn: "Numero",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "RegistrosPresencas",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                AlunaCPF = table.Column<string>(type: "varchar(11)", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TurmaNumero = table.Column<int>(type: "int", nullable: false),
                TipoDeEvento = table.Column<int>(type: "int", nullable: false),
                NumeroEvento = table.Column<int>(type: "int", nullable: false),
                Registro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                AvaliacaoId = table.Column<int>(type: "int", nullable: true),
                AvaliacaoId1 = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RegistrosPresencas", x => x.Id);
                table.ForeignKey(
                    name: "FK_RegistrosPresencas_Alunas_AlunaCPF",
                    column: x => x.AlunaCPF,
                    principalTable: "Alunas",
                    principalColumn: "CPF");
                table.ForeignKey(
                    name: "FK_RegistrosPresencas_Avaliacoes_AvaliacaoId",
                    column: x => x.AvaliacaoId,
                    principalTable: "Avaliacoes",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_RegistrosPresencas_Avaliacoes_AvaliacaoId1",
                    column: x => x.AvaliacaoId1,
                    principalTable: "Avaliacoes",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_RegistrosPresencas_Turmas_TurmaNumero",
                    column: x => x.TurmaNumero,
                    principalTable: "Turmas",
                    principalColumn: "Numero",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_Avaliacoes_AlunaCPF",
            table: "Avaliacoes",
            column: "AlunaCPF");

        migrationBuilder.CreateIndex(
            name: "IX_Avaliacoes_PresencaAberturaId",
            table: "Avaliacoes",
            column: "PresencaAberturaId");

        migrationBuilder.CreateIndex(
            name: "IX_Avaliacoes_TurmaNumero",
            table: "Avaliacoes",
            column: "TurmaNumero");

        migrationBuilder.CreateIndex(
            name: "IX_RegistrosPresencas_AlunaCPF",
            table: "RegistrosPresencas",
            column: "AlunaCPF");

        migrationBuilder.CreateIndex(
            name: "IX_RegistrosPresencas_AvaliacaoId",
            table: "RegistrosPresencas",
            column: "AvaliacaoId");

        migrationBuilder.CreateIndex(
            name: "IX_RegistrosPresencas_AvaliacaoId1",
            table: "RegistrosPresencas",
            column: "AvaliacaoId1");

        migrationBuilder.CreateIndex(
            name: "IX_RegistrosPresencas_TurmaNumero",
            table: "RegistrosPresencas",
            column: "TurmaNumero");

        migrationBuilder.AddForeignKey(
            name: "FK_Avaliacoes_RegistrosPresencas_PresencaAberturaId",
            table: "Avaliacoes",
            column: "PresencaAberturaId",
            principalTable: "RegistrosPresencas",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Avaliacoes_Alunas_AlunaCPF",
            table: "Avaliacoes");

        migrationBuilder.DropForeignKey(
            name: "FK_RegistrosPresencas_Alunas_AlunaCPF",
            table: "RegistrosPresencas");

        migrationBuilder.DropForeignKey(
            name: "FK_Avaliacoes_RegistrosPresencas_PresencaAberturaId",
            table: "Avaliacoes");

        migrationBuilder.DropTable(
            name: "Alunas");

        migrationBuilder.DropTable(
            name: "RegistrosPresencas");

        migrationBuilder.DropTable(
            name: "Avaliacoes");

        migrationBuilder.DropTable(
            name: "Turmas");
    }
}
