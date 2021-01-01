using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class addedHTMLFieldToReccomendations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HTML",
                table: "BookRecommendation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HTML",
                table: "BookRecommendation");
        }
    }
}
