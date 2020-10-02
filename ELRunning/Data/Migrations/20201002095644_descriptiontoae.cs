using Microsoft.EntityFrameworkCore.Migrations;

namespace ELRunning.Data.Migrations
{
    public partial class descriptiontoae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ActivityEvents",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ActivityEvents");
        }
    }
}
