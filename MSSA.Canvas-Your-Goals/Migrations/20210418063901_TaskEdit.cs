using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSSA.Canvas_Your_Goals.Migrations
{
    public partial class TaskEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameColumn(
                name: "OrderOf",
                table: "Task",
                newName: "TaskOrder");

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                table: "Task",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Task",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Task",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Task",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskOrder",
                table: "Tasks",
                newName: "OrderOf");

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TaskId");
        }
    }
}
