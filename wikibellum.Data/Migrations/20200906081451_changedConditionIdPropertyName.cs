using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class changedConditionIdPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Conditions_ConditionId",
                table: "Asset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conditions",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Conditions");

            migrationBuilder.AddColumn<string>(
                name: "ConditionId",
                table: "Conditions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conditions",
                table: "Conditions",
                column: "ConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Conditions_ConditionId",
                table: "Asset",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "ConditionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Conditions_ConditionId",
                table: "Asset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conditions",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "ConditionId",
                table: "Conditions");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Conditions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conditions",
                table: "Conditions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Conditions_ConditionId",
                table: "Asset",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
