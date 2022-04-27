using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imoveis.Migrations
{
    public partial class AdicionandoMetodosImoveisTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imovel_Usuario_UsuariosId",
                table: "imovel");

            migrationBuilder.DropIndex(
                name: "IX_imovel_UsuariosId",
                table: "imovel");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "imovel");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "imovel");

            migrationBuilder.AddColumn<int>(
                name: "ImovelId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ImovelId",
                table: "Usuario",
                column: "ImovelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_imovel_ImovelId",
                table: "Usuario",
                column: "ImovelId",
                principalTable: "imovel",
                principalColumn: "ImovelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_imovel_ImovelId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ImovelId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ImovelId",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "imovel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "imovel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_imovel_UsuariosId",
                table: "imovel",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_imovel_Usuario_UsuariosId",
                table: "imovel",
                column: "UsuariosId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
