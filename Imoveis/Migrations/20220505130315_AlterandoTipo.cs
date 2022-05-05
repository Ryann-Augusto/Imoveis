using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imoveis.Migrations
{
    public partial class AlterandoTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "tipo",
                table: "imovel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                table: "imovel",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
