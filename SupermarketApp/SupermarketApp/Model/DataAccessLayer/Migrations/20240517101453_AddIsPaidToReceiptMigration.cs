using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupermarketApp.Model.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPaidToReceiptMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Receipts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Receipts");
        }
    }
}
