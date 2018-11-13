using Microsoft.EntityFrameworkCore.Migrations;

namespace Albert.SimpleTaskApp.Migrations
{
    public partial class changgeGenderType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AppPersons",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AppPersons",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
