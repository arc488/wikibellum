using Microsoft.EntityFrameworkCore.Migrations;
using System;
using wikibellum.Entities.Enums;
using wikibellum.Entities.Enums.Countries;

namespace wikibellum.Data.Migrations
{
    public partial class populateAlliancesAndNationsFromRelatedEnumsViaCustomMigrationCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var alliances = Enum.GetValues(typeof(AlliancesEnum));
            var allianceCount = 1;
            foreach (var item in alliances)
            {
                migrationBuilder.InsertData(
                    table: "Alliances",
                    columns: new[] { "AllianceId", "Name" },
                    values: new object[] { allianceCount.ToString(), item.ToString() });
                allianceCount++;
            }

            var nationCount = 1;

            var allies = Enum.GetValues(typeof(AlliesEnum));
            foreach (var item in allies)
            {
                migrationBuilder.InsertData(
                    table: "Nations",
                    columns: new[] { "NationId", "Name", "AllianceId" },
                    values: new object[] { nationCount.ToString(), item.ToString(), 1 });
                nationCount++;
            }

            var axises = Enum.GetValues(typeof(AxisEnum));
            foreach (var item in axises)
            {
                migrationBuilder.InsertData(
                    table: "Nations",
                    columns: new[] { "NationId", "Name", "AllianceId" },
                    values: new object[] { nationCount.ToString(), item.ToString(), 2 });
                nationCount++;
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
