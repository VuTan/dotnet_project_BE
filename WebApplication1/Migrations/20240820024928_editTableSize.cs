using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class editTableSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSizeJunction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductSize");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductSize");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductSize",
                newName: "ProductSizeId");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "ProductSize",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize",
                columns: new[] { "ProductId", "ProductSizeId" });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductSizeId",
                table: "ProductSize",
                column: "ProductSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Products_ProductId",
                table: "ProductSize",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Size_ProductSizeId",
                table: "ProductSize",
                column: "ProductSizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Products_ProductId",
                table: "ProductSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Size_ProductSizeId",
                table: "ProductSize");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_ProductSize_ProductSizeId",
                table: "ProductSize");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductSize");

            migrationBuilder.RenameColumn(
                name: "ProductSizeId",
                table: "ProductSize",
                newName: "Id");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize",
                column: "Id");

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
    }
}
