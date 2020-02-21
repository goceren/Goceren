using Microsoft.EntityFrameworkCore.Migrations;

namespace Goceren.DataAccessLayer.Migrations
{
    public partial class Resume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_MenuType_MenuTypeId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "RightBottomTitle",
                table: "Resumepage");

            migrationBuilder.AlterColumn<int>(
                name: "MenuTypeId",
                table: "Menu",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_MenuType_MenuTypeId",
                table: "Menu",
                column: "MenuTypeId",
                principalTable: "MenuType",
                principalColumn: "MenuTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_MenuType_MenuTypeId",
                table: "Menu");

            migrationBuilder.AddColumn<string>(
                name: "RightBottomTitle",
                table: "Resumepage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuTypeId",
                table: "Menu",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_MenuType_MenuTypeId",
                table: "Menu",
                column: "MenuTypeId",
                principalTable: "MenuType",
                principalColumn: "MenuTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
