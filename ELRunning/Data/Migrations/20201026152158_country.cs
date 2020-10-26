using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELRunning.Data.Migrations
{
    public partial class country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventActivityEventID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityViewModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActivityViewModel_ActivityEvents_EventActivityEventID",
                        column: x => x.EventActivityEventID,
                        principalTable: "ActivityEvents",
                        principalColumn: "ActivityEventID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventTotal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    TotalUnits = table.Column<int>(nullable: false),
                    ActivityViewModelID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTotal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventTotal_ActivityViewModel_ActivityViewModelID",
                        column: x => x.ActivityViewModelID,
                        principalTable: "ActivityViewModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityViewModel_EventActivityEventID",
                table: "ActivityViewModel",
                column: "EventActivityEventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventTotal_ActivityViewModelID",
                table: "EventTotal",
                column: "ActivityViewModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTotal");

            migrationBuilder.DropTable(
                name: "ActivityViewModel");
        }
    }
}
