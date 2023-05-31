using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreHouse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductColorImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColorImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColorImage_ProductColor_ProductId_ColorId",
                        columns: x => new { x.ProductId, x.ColorId },
                        principalTable: "ProductColor",
                        principalColumns: new[] { "ProductId", "ColorId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorImage_ProductId_ColorId",
                table: "ProductColorImage",
                columns: new[] { "ProductId", "ColorId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductColorImage");
        }
    }
}
