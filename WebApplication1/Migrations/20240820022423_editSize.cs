using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class editSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizePrice",
                table: "ProductSize");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductSize",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ProductSize",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductSize");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductSize");

            migrationBuilder.AddColumn<string>(
                name: "SizePrice",
                table: "ProductSize",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
