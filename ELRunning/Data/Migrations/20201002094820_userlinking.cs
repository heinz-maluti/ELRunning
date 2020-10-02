using Microsoft.EntityFrameworkCore.Migrations;

namespace ELRunning.Data.Migrations
{
    public partial class userlinking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_CountryID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gender_GenderID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "ActivityEvents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_CountryID",
                table: "AspNetUsers",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gender_GenderID",
                table: "AspNetUsers",
                column: "GenderID",
                principalTable: "Gender",
                principalColumn: "GenderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_CountryID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gender_GenderID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "ActivityEvents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

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
    }
}
