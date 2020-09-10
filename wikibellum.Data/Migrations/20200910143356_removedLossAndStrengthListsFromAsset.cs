using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class removedLossAndStrengthListsFromAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_EventParticipants_EventParticipantId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Events_EventId",
                table: "EventParticipants");

            migrationBuilder.DropIndex(
                name: "IX_EventParticipants_EventId",
                table: "EventParticipants");

            migrationBuilder.DropIndex(
                name: "IX_Asset_EventParticipantId",
                table: "Asset");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                table: "EventParticipants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventParticipantId",
                table: "Asset",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Events_EventId1",
                table: "EventParticipants");

            migrationBuilder.DropIndex(
                name: "IX_EventParticipants_EventId1",
                table: "EventParticipants");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "EventParticipants");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventParticipants",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventParticipantId",
                table: "Asset",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_EventId",
                table: "EventParticipants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_EventParticipantId",
                table: "Asset",
                column: "EventParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_EventParticipants_EventParticipantId",
                table: "Asset",
                column: "EventParticipantId",
                principalTable: "EventParticipants",
                principalColumn: "EventParticipantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Events_EventId",
                table: "EventParticipants",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
