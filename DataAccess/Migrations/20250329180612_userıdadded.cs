using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class userıdadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Expenses",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Revenues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Expenses",
                newName: "Category");
        }
    }
}
