using Microsoft.EntityFrameworkCore.Migrations;
using System;
using wikibellum.Entities.Enums;

namespace wikibellum.Data.Migrations
{
    public partial class populateCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Nations_NationId",
                table: "EventParticipants");

            migrationBuilder.AlterColumn<int>(
                name: "NationId",
                table: "EventParticipants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Nations_NationId",
                table: "EventParticipants",
                column: "NationId",
                principalTable: "Nations",
                principalColumn: "NationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.InsertData(
                table: "Nations",
                columns: new[] { "NationId", "Name", "AllianceId" },
                values: new object[] { 0, "Unknown", 0 });

            int nationId = 1;
            foreach (var item in Enum.GetValues(typeof(AlliesEnum)))
            {
                var fullName = item.ToString().Replace("_", " ");
                migrationBuilder.InsertData(
                    table: "Nations",
                    columns: new[] { "NationId", "Name", "AllianceId" },
                    values: new object[] { nationId, fullName, 0 });
                nationId++;
            }

            foreach (var item in Enum.GetValues(typeof(AxisEnum)))
            {
                var fullName = item.ToString().Replace("_", " ");
                migrationBuilder.InsertData(
                    table: "Nations",
                    columns: new[] { "NationId", "Name", "AllianceId" },
                    values: new object[] { nationId, fullName, 1 });
                nationId++;
            }


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Nations_NationId",
                table: "EventParticipants");

            migrationBuilder.AlterColumn<int>(
                name: "NationId",
                table: "EventParticipants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Nations_NationId",
                table: "EventParticipants",
                column: "NationId",
                principalTable: "Nations",
                principalColumn: "NationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
