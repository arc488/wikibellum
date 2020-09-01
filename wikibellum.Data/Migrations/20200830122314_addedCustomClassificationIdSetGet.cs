using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class addedCustomClassificationIdSetGet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Classifications_ClassificationId",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_ClassificationId",
                table: "Asset");

            migrationBuilder.AlterColumn<string>(
                name: "ClassificationId",
                table: "Asset",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClassificationId1",
                table: "Asset",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ClassificationId1",
                table: "Asset",
                column: "ClassificationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Classifications_ClassificationId1",
                table: "Asset",
                column: "ClassificationId1",
                principalTable: "Classifications",
                principalColumn: "ClassificationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Classifications_ClassificationId1",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_ClassificationId1",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ClassificationId1",
                table: "Asset");

            migrationBuilder.AlterColumn<int>(
                name: "ClassificationId",
                table: "Asset",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ClassificationId",
                table: "Asset",
                column: "ClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Classifications_ClassificationId",
                table: "Asset",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "ClassificationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
