using Microsoft.EntityFrameworkCore.Migrations;

namespace TheThreeOwlsWebApp.Data.Migrations
{
    public partial class PositionOfTheCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Courses");
        }
    }
}
