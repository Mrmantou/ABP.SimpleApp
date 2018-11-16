using Microsoft.EntityFrameworkCore.Migrations;

namespace Albert.SimpleTaskApp.Migrations
{
    public partial class addPersonAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AppPersons",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AppPersons");
        }
    }
}
