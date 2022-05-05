using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imoveis.Migrations
{
    public partial class AdicionandoCpfTelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "usuario",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "telefone",
                table: "usuario",
                type: "varchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cpf",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "telefone",
                table: "usuario");
        }
    }
}
