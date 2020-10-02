using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELRunning.Data.Migrations
{
    public partial class users3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEvents_EventTypes_EventTypeID",
                table: "ActivityEvents");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventTypeID",
                table: "ActivityEvents",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEvents_EventTypes_EventTypeID",
                table: "ActivityEvents",
                column: "EventTypeID",
                principalTable: "EventTypes",
                principalColumn: "EventTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEvents_EventTypes_EventTypeID",
                table: "ActivityEvents");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventTypeID",
                table: "ActivityEvents",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEvents_EventTypes_EventTypeID",
                table: "ActivityEvents",
                column: "EventTypeID",
                principalTable: "EventTypes",
                principalColumn: "EventTypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
