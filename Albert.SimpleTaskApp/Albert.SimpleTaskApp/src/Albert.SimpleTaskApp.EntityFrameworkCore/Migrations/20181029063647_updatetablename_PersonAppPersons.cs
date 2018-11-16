using Microsoft.EntityFrameworkCore.Migrations;

namespace Albert.SimpleTaskApp.Migrations
{
    public partial class updatetablename_PersonAppPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_AppTask_AssignedPersonId",
                table: "AppTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppTask",
                table: "AppTask");

            migrationBuilder.RenameTable(
                name: "AppTask",
                newName: "AppPersons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPersons",
                table: "AppPersons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTasks_AppPersons_AssignedPersonId",
                table: "AppTasks",
                column: "AssignedPersonId",
                principalTable: "AppPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_AppPersons_AssignedPersonId",
                table: "AppTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPersons",
                table: "AppPersons");

            migrationBuilder.RenameTable(
                name: "AppPersons",
                newName: "AppTask");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppTask",
                table: "AppTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTasks_AppTask_AssignedPersonId",
                table: "AppTasks",
                column: "AssignedPersonId",
                principalTable: "AppTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
