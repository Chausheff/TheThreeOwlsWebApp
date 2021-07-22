using Microsoft.EntityFrameworkCore.Migrations;

namespace TheThreeOwlsWebApp.Data.Migrations
{
    public partial class AddCourseForKidsBoolean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ForKids",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForKids",
                table: "Courses");
        }
    }
}
