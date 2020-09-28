using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELRunning.Data.Migrations
{
    public partial class EventTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "ActivityLogs");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "ActivityEvents");

            migrationBuilder.AddColumn<int>(
                name: "Units",
                table: "ActivityLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "EventTypeID",
                table: "ActivityEvents",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    EventTypeID = table.Column<Guid>(nullable: false),
                    TypeName = table.Column<string>(nullable: true),
                    UnitType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.EventTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEvents_EventTypeID",
                table: "ActivityEvents",
                column: "EventTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEvents_EventType_EventTypeID",
                table: "ActivityEvents",
                column: "EventTypeID",
                principalTable: "EventType",
                principalColumn: "EventTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEvents_EventType_EventTypeID",
                table: "ActivityEvents");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropIndex(
                name: "IX_ActivityEvents_EventTypeID",
                table: "ActivityEvents");

            migrationBuilder.DropColumn(
                name: "Units",
                table: "ActivityLogs");

            migrationBuilder.DropColumn(
                name: "EventTypeID",
                table: "ActivityEvents");

            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "ActivityLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventType",
                table: "ActivityEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
