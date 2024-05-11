using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreHouse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CssCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductColor",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColor", x => new { x.ProductId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_ProductColor_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductColor_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "Order" },
                values: new object[,]
                {
                    { 1, "Shoes", 1 },
                    { 2, "Jackets", 2 },
                    { 3, "Shirts", 3 },
                    { 4, "T-Shirts", 4 },
                    { 5, "Bags", 5 },
                    { 6, "Trousers", 6 },
                    { 7, "Jeans", 7 },
                    { 8, "Dresses", 8 }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "CssCode", "Order", "Title" },
                values: new object[,]
                {
                    { 1, "FFFFFF", 1, "White" },
                    { 2, "808080", 2, "Gray" },
                    { 3, "006400", 3, "Dark Green" },
                    { 4, "F5F5DC", 4, "Beige" },
                    { 5, "0000FF", 5, "Blue" },
                    { 6, "6A6957", 6, "Gray green" },
                    { 7, "000000", 7, "Black" },
                    { 8, "293141", 8, "Navy" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 3, "Relaxed-fit shirt made of a linen blend. Button-down collar. Long sleeves with buttoned cuffs. Chest patch pocket. Button-up front.", 1499.0, "COTTON - LINEN SHIRT" },
                    { 2, 6, "Wide-fit trousers made of lightweight technical fabric. Elasticated waistband with front pleats and metal ring detail. Front pockets and back welt pockets. Zip fly front fastening and snap button fastening.", 1899.0, "PLEATED TECHNICAL TROUSERS" },
                    { 3, 3, "Relaxed-fit shirt made of a linen blend. Button-down collar. Long sleeves with buttoned cuffs. Chest patch pocket. Button-up front.", 1499.0, "STRIPED CROCHET SHIRT" },
                    { 4, 6, "Trousers featuring an adjustable elastic waistband with drawstrings. Front pockets and rear welt pockets.", 1499.0, "TEXTURED TROUSERS" },
                    { 5, 6, "Relaxed-fit shirt made of a linen blend. Button-down collar. Long sleeves with buttoned cuffs. Chest patch pocket. Button-up front.", 1499.0, "COTTON - LINEN TROUSERS" },
                    { 6, 3, "Carrot fit trousers with front pockets, rear welt pockets and front zip fly and top button fastening.", 1499.0, "PLEATED CHINO TROUSERS" }
                });

            migrationBuilder.InsertData(
                table: "ProductColor",
                columns: new[] { "ColorId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 4, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 1, 6 },
                    { 4, 6 },
                    { 8, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_ColorId",
                table: "ProductColor",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductColor");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
