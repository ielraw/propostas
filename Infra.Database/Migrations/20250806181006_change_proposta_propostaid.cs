using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Database.Migrations
{
    /// <inheritdoc />
    public partial class change_proposta_propostaid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratacoes_Propostas_PropostaId1",
                table: "Contratacoes");

            migrationBuilder.DropIndex(
                name: "IX_Contratacoes_PropostaId1",
                table: "Contratacoes");

            migrationBuilder.DropColumn(
                name: "PropostaId1",
                table: "Contratacoes");

            migrationBuilder.AlterColumn<string>(
                name: "PropostaId",
                table: "Contratacoes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Contratacoes_PropostaId",
                table: "Contratacoes",
                column: "PropostaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratacoes_Propostas_PropostaId",
                table: "Contratacoes",
                column: "PropostaId",
                principalTable: "Propostas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratacoes_Propostas_PropostaId",
                table: "Contratacoes");

            migrationBuilder.DropIndex(
                name: "IX_Contratacoes_PropostaId",
                table: "Contratacoes");

            migrationBuilder.AlterColumn<int>(
                name: "PropostaId",
                table: "Contratacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PropostaId1",
                table: "Contratacoes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contratacoes_PropostaId1",
                table: "Contratacoes",
                column: "PropostaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratacoes_Propostas_PropostaId1",
                table: "Contratacoes",
                column: "PropostaId1",
                principalTable: "Propostas",
                principalColumn: "Id");
        }
    }
}
