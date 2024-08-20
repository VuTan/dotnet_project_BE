using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class editSize2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Products_ProductId",
                table: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_ProductSize_ProductId",
                table: "ProductSize");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductSize");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Products_Id",
                table: "ProductSize",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Products_Id",
                table: "ProductSize");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "ProductSize",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductId",
                table: "ProductSize",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Products_ProductId",
                table: "ProductSize",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
