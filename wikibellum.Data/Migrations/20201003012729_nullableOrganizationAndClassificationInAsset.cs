using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class nullableOrganizationAndClassificationInAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Classifications_ClassificationId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Organizations_OrganizationId",
                table: "Assets");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "Assets",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassificationId",
                table: "Assets",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Classifications_ClassificationId",
                table: "Assets",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "ClassificationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Organizations_OrganizationId",
                table: "Assets",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Classifications_ClassificationId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Organizations_OrganizationId",
                table: "Assets");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "Assets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassificationId",
                table: "Assets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Classifications_ClassificationId",
                table: "Assets",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "ClassificationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Organizations_OrganizationId",
                table: "Assets",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
