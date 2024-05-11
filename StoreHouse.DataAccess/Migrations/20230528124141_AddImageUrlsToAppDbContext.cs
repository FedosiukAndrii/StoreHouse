using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreHouse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlsToAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColorImage_ProductColor_ProductId_ColorId",
                table: "ProductColorImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductColorImage",
                table: "ProductColorImage");

            migrationBuilder.RenameTable(
                name: "ProductColorImage",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColorImage_ProductId_ColorId",
                table: "Images",
                newName: "IX_Images_ProductId_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ProductColor_ProductId_ColorId",
                table: "Images",
                columns: new[] { "ProductId", "ColorId" },
                principalTable: "ProductColor",
                principalColumns: new[] { "ProductId", "ColorId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ProductColor_ProductId_ColorId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "ProductColorImage");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ProductId_ColorId",
                table: "ProductColorImage",
                newName: "IX_ProductColorImage_ProductId_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductColorImage",
                table: "ProductColorImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColorImage_ProductColor_ProductId_ColorId",
                table: "ProductColorImage",
                columns: new[] { "ProductId", "ColorId" },
                principalTable: "ProductColor",
                principalColumns: new[] { "ProductId", "ColorId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
