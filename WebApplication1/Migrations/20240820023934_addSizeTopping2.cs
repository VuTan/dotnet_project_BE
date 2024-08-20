using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addSizeTopping2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Products_Id",
                table: "ProductSize");

            migrationBuilder.CreateTable(
                name: "ProductSizeJunction",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductSizeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizeJunction", x => new { x.ProductId, x.ProductSizeId });
                    table.ForeignKey(
                        name: "FK_ProductSizeJunction_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizeJunction_ProductSize_ProductSizeId",
                        column: x => x.ProductSizeId,
                        principalTable: "ProductSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizeJunction_ProductSizeId",
                table: "ProductSizeJunction",
                column: "ProductSizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSizeJunction");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Products_Id",
                table: "ProductSize",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
