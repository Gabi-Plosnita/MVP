using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupermarketApp.Model.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddNamePropertyToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryType",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryType",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
