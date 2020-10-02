using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELRunning.Data.Migrations
{
    public partial class users2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GenderID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<Guid>(nullable: false),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderID = table.Column<Guid>(nullable: false),
                    GenderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountryID",
                table: "AspNetUsers",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderID",
                table: "AspNetUsers",
                column: "GenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_CountryID",
                table: "AspNetUsers",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gender_GenderID",
                table: "AspNetUsers",
                column: "GenderID",
                principalTable: "Gender",
                principalColumn: "GenderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_CountryID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gender_GenderID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CountryID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GenderID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GenderID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
