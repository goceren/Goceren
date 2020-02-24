using Microsoft.EntityFrameworkCore.Migrations;

namespace Goceren.DataAccessLayer.Migrations
{
    public partial class adminsaw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SawAdmin",
                table: "Blog",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SawAdmin",
                table: "Blog");
        }
    }
}
