using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class addedConditionModelDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Asset");

            migrationBuilder.AddColumn<string>(
                name: "ConditionId",
                table: "Asset",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ConditionId",
                table: "Asset",
                column: "ConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Conditions_ConditionId",
                table: "Asset",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Conditions_ConditionId",
                table: "Asset");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropIndex(
                name: "IX_Asset_ConditionId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ConditionId",
                table: "Asset");

            migrationBuilder.AddColumn<int>(
                name: "Condition",
                table: "Asset",
                type: "int",
                nullable: true);
        }
    }
}
