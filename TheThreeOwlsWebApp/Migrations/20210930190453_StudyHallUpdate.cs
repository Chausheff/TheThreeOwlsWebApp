using Microsoft.EntityFrameworkCore.Migrations;

namespace TheThreeOwlsWebApp.Migrations
{
    public partial class StudyHallUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Educational",
                table: "StudyHalls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Educational",
                table: "StudyHalls");
        }
    }
}
