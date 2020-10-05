using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class addedSingularAndPluralToClassificationAndOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("FullName", "Classifications", "Singular");

            migrationBuilder.RenameColumn("Name", "Organizations", "Singular");

            migrationBuilder.DropColumn(
                name: "AbbrName",
                table: "Classifications");

            migrationBuilder.AddColumn<string>(
                name: "Plural",
                table: "Organizations",
                nullable: true);


            migrationBuilder.AddColumn<string>(
                name: "Plural",
                table: "Classifications",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plural",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Singular",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Plural",
                table: "Classifications");

            migrationBuilder.DropColumn(
                name: "Singular",
                table: "Classifications");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AbbrName",
                table: "Classifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Classifications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
