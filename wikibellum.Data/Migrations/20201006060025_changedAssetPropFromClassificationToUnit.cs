using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class changedAssetPropFromClassificationToUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Classifications_ClassificationId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_ClassificationId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "Assets");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Assets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UnitId",
                table: "Assets",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Units_UnitId",
                table: "Assets",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Units_UnitId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_UnitId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Assets");

            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ClassificationId",
                table: "Assets",
                column: "ClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Classifications_ClassificationId",
                table: "Assets",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "ClassificationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
