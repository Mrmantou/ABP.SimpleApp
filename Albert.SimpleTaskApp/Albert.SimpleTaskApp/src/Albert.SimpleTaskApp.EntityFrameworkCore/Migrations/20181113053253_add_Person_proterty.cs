using Microsoft.EntityFrameworkCore.Migrations;

namespace Albert.SimpleTaskApp.Migrations
{
    public partial class add_Person_proterty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AppPersons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AppPersons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AppPersons",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AppPersons",
                maxLength: 13,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AppPersons");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AppPersons");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AppPersons");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AppPersons");
        }
    }
}
