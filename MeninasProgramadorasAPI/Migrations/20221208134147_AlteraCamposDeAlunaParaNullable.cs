using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeninasProgramadorasAPI.Migrations
{
    public partial class AlteraCamposDeAlunaParaNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Alunas_AlunaCPF",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Turmas_TurmaNumero",
                table: "Avaliacoes");

            migrationBuilder.RenameColumn(
                name: "TurmaNumero",
                table: "Avaliacoes",
                newName: "TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacoes_TurmaNumero",
                table: "Avaliacoes",
                newName: "IX_Avaliacoes_TurmaId");

            migrationBuilder.UpdateData(
                table: "Avaliacoes",
                keyColumn: "AlunaCPF",
                keyValue: null,
                column: "AlunaCPF",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "AlunaCPF",
                table: "Avaliacoes",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AlunaId",
                table: "Avaliacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Alunas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BeecrowdId",
                table: "Alunas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Alunas_AlunaCPF",
                table: "Avaliacoes",
                column: "AlunaCPF",
                principalTable: "Alunas",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Turmas_TurmaId",
                table: "Avaliacoes",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Alunas_AlunaCPF",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Turmas_TurmaId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "AlunaId",
                table: "Avaliacoes");

            migrationBuilder.RenameColumn(
                name: "TurmaId",
                table: "Avaliacoes",
                newName: "TurmaNumero");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacoes_TurmaId",
                table: "Avaliacoes",
                newName: "IX_Avaliacoes_TurmaNumero");

            migrationBuilder.AlterColumn<string>(
                name: "AlunaCPF",
                table: "Avaliacoes",
                type: "varchar(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Alunas",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Alunas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Alunas",
                keyColumn: "BeecrowdId",
                keyValue: null,
                column: "BeecrowdId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "BeecrowdId",
                table: "Alunas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Alunas_AlunaCPF",
                table: "Avaliacoes",
                column: "AlunaCPF",
                principalTable: "Alunas",
                principalColumn: "CPF");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Turmas_TurmaNumero",
                table: "Avaliacoes",
                column: "TurmaNumero",
                principalTable: "Turmas",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
