using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imoveis.Migrations
{
    public partial class RemovendoNiveis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imovel_Usuario_usuarioid",
                table: "imovel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "nivel",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "usuario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "usuario",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "imovelvlr",
                table: "imovel",
                newName: "valor");

            migrationBuilder.RenameColumn(
                name: "imoveluf",
                table: "imovel",
                newName: "estado");

            migrationBuilder.RenameColumn(
                name: "imoveltip",
                table: "imovel",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "imovelrua",
                table: "imovel",
                newName: "endereco");

            migrationBuilder.RenameColumn(
                name: "imovelnumvag",
                table: "imovel",
                newName: "vagas");

            migrationBuilder.RenameColumn(
                name: "imovelnumQrt",
                table: "imovel",
                newName: "quartos");

            migrationBuilder.RenameColumn(
                name: "imoveldsc",
                table: "imovel",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "imovelcep",
                table: "imovel",
                newName: "cep");

            migrationBuilder.RenameColumn(
                name: "imovelcdd",
                table: "imovel",
                newName: "cidade");

            migrationBuilder.RenameColumn(
                name: "imovelbro",
                table: "imovel",
                newName: "bairro");

            migrationBuilder.RenameColumn(
                name: "ImovelId",
                table: "imovel",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_imovel_usuario_usuarioid",
                table: "imovel",
                column: "usuarioid",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imovel_usuario_usuarioid",
                table: "imovel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usuario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "valor",
                table: "imovel",
                newName: "imovelvlr");

            migrationBuilder.RenameColumn(
                name: "vagas",
                table: "imovel",
                newName: "imovelnumvag");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "imovel",
                newName: "imoveltip");

            migrationBuilder.RenameColumn(
                name: "quartos",
                table: "imovel",
                newName: "imovelnumQrt");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "imovel",
                newName: "imoveluf");

            migrationBuilder.RenameColumn(
                name: "endereco",
                table: "imovel",
                newName: "imovelrua");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "imovel",
                newName: "imoveldsc");

            migrationBuilder.RenameColumn(
                name: "cidade",
                table: "imovel",
                newName: "imovelcdd");

            migrationBuilder.RenameColumn(
                name: "cep",
                table: "imovel",
                newName: "imovelcep");

            migrationBuilder.RenameColumn(
                name: "bairro",
                table: "imovel",
                newName: "imovelbro");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "imovel",
                newName: "ImovelId");

            migrationBuilder.AddColumn<int>(
                name: "nivel",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_imovel_Usuario_usuarioid",
                table: "imovel",
                column: "usuarioid",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
