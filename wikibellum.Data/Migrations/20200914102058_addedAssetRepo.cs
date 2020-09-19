using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class addedAssetRepo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Classifications_ClassificationId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Conditions_ConditionId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_EventParticipants_EventParticipantId",
                table: "Asset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asset",
                table: "Asset");

            migrationBuilder.RenameTable(
                name: "Asset",
                newName: "Assets");

            migrationBuilder.RenameIndex(
                name: "IX_Asset_EventParticipantId",
                table: "Assets",
                newName: "IX_Assets_EventParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Asset_ConditionId",
                table: "Assets",
                newName: "IX_Assets_ConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_Asset_ClassificationId",
                table: "Assets",
                newName: "IX_Assets_ClassificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assets",
                table: "Assets",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Classifications_ClassificationId",
                table: "Assets",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "ClassificationId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Conditions_ConditionId",
                table: "Assets",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "ConditionId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_EventParticipants_EventParticipantId",
                table: "Assets",
                column: "EventParticipantId",
                principalTable: "EventParticipants",
                principalColumn: "EventParticipantId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Classifications_ClassificationId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Conditions_ConditionId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_EventParticipants_EventParticipantId",
                table: "Assets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assets",
                table: "Assets");

            migrationBuilder.RenameTable(
                name: "Assets",
                newName: "Asset");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_EventParticipantId",
                table: "Asset",
                newName: "IX_Asset_EventParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_ConditionId",
                table: "Asset",
                newName: "IX_Asset_ConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_ClassificationId",
                table: "Asset",
                newName: "IX_Asset_ClassificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asset",
                table: "Asset",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Classifications_ClassificationId",
                table: "Asset",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "ClassificationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Conditions_ConditionId",
                table: "Asset",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "ConditionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_EventParticipants_EventParticipantId",
                table: "Asset",
                column: "EventParticipantId",
                principalTable: "EventParticipants",
                principalColumn: "EventParticipantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
