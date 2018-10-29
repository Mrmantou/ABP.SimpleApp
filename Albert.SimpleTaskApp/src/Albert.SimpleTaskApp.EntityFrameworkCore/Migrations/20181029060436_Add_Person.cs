using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Albert.SimpleTaskApp.Migrations
{
    public partial class Add_Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssignedPersonId",
                table: "AppTasks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_AssignedPersonId",
                table: "AppTasks",
                column: "AssignedPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTasks_People_AssignedPersonId",
                table: "AppTasks",
                column: "AssignedPersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_People_AssignedPersonId",
                table: "AppTasks");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropIndex(
                name: "IX_AppTasks_AssignedPersonId",
                table: "AppTasks");

            migrationBuilder.DropColumn(
                name: "AssignedPersonId",
                table: "AppTasks");
        }
    }
}
