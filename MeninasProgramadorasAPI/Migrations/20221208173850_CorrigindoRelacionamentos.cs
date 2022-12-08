using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeninasProgramadorasAPI.Migrations
{
    public partial class CorrigindoRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Alunas_AlunaCPF",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_RegistrosPresencas_PresencaAberturaId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Turmas_TurmaId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosPresencas_Alunas_AlunaCPF",
                table: "RegistrosPresencas");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosPresencas_Avaliacoes_AvaliacaoId",
                table: "RegistrosPresencas");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosPresencas_Avaliacoes_AvaliacaoId1",
                table: "RegistrosPresencas");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosPresencas_Turmas_TurmaNumero",
                table: "RegistrosPresencas");

            migrationBuilder.DropIndex(
                name: "IX_RegistrosPresencas_AlunaCPF",
                table: "RegistrosPresencas");

            migrationBuilder.DropIndex(
                name: "IX_RegistrosPresencas_AvaliacaoId1",
                table: "RegistrosPresencas");

            migrationBuilder.DropIndex(
                name: "IX_RegistrosPresencas_TurmaNumero",
                table: "RegistrosPresencas");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_AlunaCPF",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_PresencaAberturaId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "AlunaCPF",
                table: "RegistrosPresencas");

            migrationBuilder.DropColumn(
                name: "AvaliacaoId1",
                table: "RegistrosPresencas");

            migrationBuilder.DropColumn(
                name: "TurmaNumero",
                table: "RegistrosPresencas");

            migrationBuilder.DropColumn(
                name: "AlunaId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "PresencaAberturaId",
                table: "Avaliacoes");

            migrationBuilder.RenameColumn(
                name: "TurmaId",
                table: "Avaliacoes",
                newName: "TurmaNumero");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacoes_TurmaId",
                table: "Avaliacoes",
                newName: "IX_Avaliacoes_TurmaNumero");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroEvento",
                table: "RegistrosPresencas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AvaliacaoId",
                table: "RegistrosPresencas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlunaCPF",
                table: "Avaliacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AlunaCPF1",
                table: "Avaliacoes",
                type: "varchar(11)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_AlunaCPF1",
                table: "Avaliacoes",
                column: "AlunaCPF1");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Alunas_AlunaCPF1",
                table: "Avaliacoes",
                column: "AlunaCPF1",
                principalTable: "Alunas",
                principalColumn: "CPF");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Turmas_TurmaNumero",
                table: "Avaliacoes",
                column: "TurmaNumero",
                principalTable: "Turmas",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosPresencas_Avaliacoes_AvaliacaoId",
                table: "RegistrosPresencas",
                column: "AvaliacaoId",
                principalTable: "Avaliacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Alunas_AlunaCPF1",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Turmas_TurmaNumero",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosPresencas_Avaliacoes_AvaliacaoId",
                table: "RegistrosPresencas");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_AlunaCPF1",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "AlunaCPF1",
                table: "Avaliacoes");

            migrationBuilder.RenameColumn(
                name: "TurmaNumero",
                table: "Avaliacoes",
                newName: "TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacoes_TurmaNumero",
                table: "Avaliacoes",
                newName: "IX_Avaliacoes_TurmaId");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroEvento",
                table: "RegistrosPresencas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AvaliacaoId",
                table: "RegistrosPresencas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AlunaCPF",
                table: "RegistrosPresencas",
                type: "varchar(11)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoId1",
                table: "RegistrosPresencas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TurmaNumero",
                table: "RegistrosPresencas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AlunaCPF",
                table: "Avaliacoes",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AlunaId",
                table: "Avaliacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PresencaAberturaId",
                table: "Avaliacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosPresencas_AlunaCPF",
                table: "RegistrosPresencas",
                column: "AlunaCPF");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosPresencas_AvaliacaoId1",
                table: "RegistrosPresencas",
                column: "AvaliacaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosPresencas_TurmaNumero",
                table: "RegistrosPresencas",
                column: "TurmaNumero");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_AlunaCPF",
                table: "Avaliacoes",
                column: "AlunaCPF");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_PresencaAberturaId",
                table: "Avaliacoes",
                column: "PresencaAberturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Alunas_AlunaCPF",
                table: "Avaliacoes",
                column: "AlunaCPF",
                principalTable: "Alunas",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_RegistrosPresencas_PresencaAberturaId",
                table: "Avaliacoes",
                column: "PresencaAberturaId",
                principalTable: "RegistrosPresencas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Turmas_TurmaId",
                table: "Avaliacoes",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosPresencas_Alunas_AlunaCPF",
                table: "RegistrosPresencas",
                column: "AlunaCPF",
                principalTable: "Alunas",
                principalColumn: "CPF");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosPresencas_Avaliacoes_AvaliacaoId",
                table: "RegistrosPresencas",
                column: "AvaliacaoId",
                principalTable: "Avaliacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosPresencas_Avaliacoes_AvaliacaoId1",
                table: "RegistrosPresencas",
                column: "AvaliacaoId1",
                principalTable: "Avaliacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosPresencas_Turmas_TurmaNumero",
                table: "RegistrosPresencas",
                column: "TurmaNumero",
                principalTable: "Turmas",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
