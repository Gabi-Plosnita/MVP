using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupermarketApp.Model.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddProductReceiptIdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductReceipts",
                table: "ProductReceipts");

            migrationBuilder.AddColumn<int>(
                name: "ProductReceiptId",
                table: "ProductReceipts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductReceipts",
                table: "ProductReceipts",
                column: "ProductReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReceipts_ReceiptId",
                table: "ProductReceipts",
                column: "ReceiptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductReceipts",
                table: "ProductReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ProductReceipts_ReceiptId",
                table: "ProductReceipts");

            migrationBuilder.DropColumn(
                name: "ProductReceiptId",
                table: "ProductReceipts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductReceipts",
                table: "ProductReceipts",
                columns: new[] { "ReceiptId", "ProductId" });
        }
    }
}
