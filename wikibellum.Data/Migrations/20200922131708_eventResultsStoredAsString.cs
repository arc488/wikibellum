using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class eventResultsStoredAsString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Results",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "ResultsAsString",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResultsAsString",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Results",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
