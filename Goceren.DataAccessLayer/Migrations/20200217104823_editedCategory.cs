using Microsoft.EntityFrameworkCore.Migrations;

namespace Goceren.DataAccessLayer.Migrations
{
    public partial class editedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isValid",
                table: "Category");

            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "Category",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "Category");

            migrationBuilder.AddColumn<bool>(
                name: "isValid",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
