using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class changedResultToListOfStringsInEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Results",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Results",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
