using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ItemValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
