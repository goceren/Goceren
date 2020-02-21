using Microsoft.EntityFrameworkCore.Migrations;

namespace Goceren.DataAccessLayer.Migrations
{
    public partial class portfolioEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_Resumepage_ResumepageId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_Resumepage_ResumepageId",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Resumepage_ResumepageId",
                table: "Skills");

            migrationBuilder.AlterColumn<int>(
                name: "ResumepageId",
                table: "Skills",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "Portfoliopage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ResumepageId",
                table: "Experience",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ResumepageId",
                table: "Education",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Resumepage_ResumepageId",
                table: "Education",
                column: "ResumepageId",
                principalTable: "Resumepage",
                principalColumn: "ResumepageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_Resumepage_ResumepageId",
                table: "Experience",
                column: "ResumepageId",
                principalTable: "Resumepage",
                principalColumn: "ResumepageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Resumepage_ResumepageId",
                table: "Skills",
                column: "ResumepageId",
                principalTable: "Resumepage",
                principalColumn: "ResumepageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_Resumepage_ResumepageId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_Resumepage_ResumepageId",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Resumepage_ResumepageId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "Portfoliopage");

            migrationBuilder.AlterColumn<int>(
                name: "ResumepageId",
                table: "Skills",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResumepageId",
                table: "Experience",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResumepageId",
                table: "Education",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Resumepage_ResumepageId",
                table: "Education",
                column: "ResumepageId",
                principalTable: "Resumepage",
                principalColumn: "ResumepageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_Resumepage_ResumepageId",
                table: "Experience",
                column: "ResumepageId",
                principalTable: "Resumepage",
                principalColumn: "ResumepageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Resumepage_ResumepageId",
                table: "Skills",
                column: "ResumepageId",
                principalTable: "Resumepage",
                principalColumn: "ResumepageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
