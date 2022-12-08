using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeninasProgramadorasAPI.Migrations
{
    public partial class AtualizacaoPresencas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosPresencas_Avaliacoes_AvaliacaoId",
                table: "RegistrosPresencas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrosPresencas",
                table: "RegistrosPresencas");

            migrationBuilder.RenameTable(
                name: "RegistrosPresencas",
                newName: "Presencas");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosPresencas_AvaliacaoId",
                table: "Presencas",
                newName: "IX_Presencas_AvaliacaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Presencas",
                table: "Presencas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Presencas_Avaliacoes_AvaliacaoId",
                table: "Presencas",
                column: "AvaliacaoId",
                principalTable: "Avaliacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presencas_Avaliacoes_AvaliacaoId",
                table: "Presencas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Presencas",
                table: "Presencas");

            migrationBuilder.RenameTable(
                name: "Presencas",
                newName: "RegistrosPresencas");

            migrationBuilder.RenameIndex(
                name: "IX_Presencas_AvaliacaoId",
                table: "RegistrosPresencas",
                newName: "IX_RegistrosPresencas_AvaliacaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrosPresencas",
                table: "RegistrosPresencas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosPresencas_Avaliacoes_AvaliacaoId",
                table: "RegistrosPresencas",
                column: "AvaliacaoId",
                principalTable: "Avaliacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
