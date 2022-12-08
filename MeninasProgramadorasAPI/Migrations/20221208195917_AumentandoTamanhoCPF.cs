using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeninasProgramadorasAPI.Migrations
{
    public partial class AumentandoTamanhoCPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Alunas_AlunaCPF1",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_AlunaCPF1",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "AlunaCPF1",
                table: "Avaliacoes");

            migrationBuilder.AlterColumn<string>(
                name: "AlunaCPF",
                table: "Avaliacoes",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Alunas",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_AlunaCPF",
                table: "Avaliacoes",
                column: "AlunaCPF");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Alunas_AlunaCPF",
                table: "Avaliacoes",
                column: "AlunaCPF",
                principalTable: "Alunas",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Alunas_AlunaCPF",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_AlunaCPF",
                table: "Avaliacoes");

            migrationBuilder.AlterColumn<int>(
                name: "AlunaCPF",
                table: "Avaliacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AlunaCPF1",
                table: "Avaliacoes",
                type: "varchar(11)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Alunas",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
        }
    }
}
