using Microsoft.EntityFrameworkCore.Migrations;

namespace Goceren.DataAccessLayer.Migrations
{
    public partial class blogUserConfirm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BlogConfirm",
                table: "Blog",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogConfirm",
                table: "Blog");
        }
    }
}
