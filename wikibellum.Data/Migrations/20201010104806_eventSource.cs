using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class eventSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Organizations_OrganizationId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_OrganizationId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Assets");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_OrganizationId",
                table: "Assets",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Organizations_OrganizationId",
                table: "Assets",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
