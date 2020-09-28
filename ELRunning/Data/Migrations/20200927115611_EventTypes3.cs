using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELRunning.Data.Migrations
{
    public partial class EventTypes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EventTypeID",
                table: "ActivityLogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_EventTypeID",
                table: "ActivityLogs",
                column: "EventTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLogs_EventTypes_EventTypeID",
                table: "ActivityLogs",
                column: "EventTypeID",
                principalTable: "EventTypes",
                principalColumn: "EventTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLogs_EventTypes_EventTypeID",
                table: "ActivityLogs");

            migrationBuilder.DropIndex(
                name: "IX_ActivityLogs_EventTypeID",
                table: "ActivityLogs");

            migrationBuilder.DropColumn(
                name: "EventTypeID",
                table: "ActivityLogs");
        }
    }
}
