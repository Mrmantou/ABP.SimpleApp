using Microsoft.EntityFrameworkCore.Migrations;

namespace Albert.SimpleTaskApp.Migrations
{
    public partial class updatetablename_Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_People_AssignedPersonId",
                table: "AppTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
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
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_AppTask_AssignedPersonId",
                table: "AppTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppTask",
                table: "AppTask");

            migrationBuilder.RenameTable(
                name: "AppTask",
                newName: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTasks_People_AssignedPersonId",
                table: "AppTasks",
                column: "AssignedPersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
