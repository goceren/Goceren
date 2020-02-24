using Microsoft.EntityFrameworkCore.Migrations;

namespace Goceren.DataAccessLayer.Migrations
{
    public partial class blogUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BlogUser",
                table: "Blog",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogUser",
                table: "Blog");
        }
    }
}
