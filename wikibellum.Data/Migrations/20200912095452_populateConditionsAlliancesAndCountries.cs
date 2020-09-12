using Microsoft.EntityFrameworkCore.Migrations;
using System;
using wikibellum.Entities.Enums;
using wikibellum.Entities.Enums.Countries;

namespace wikibellum.Data.Migrations
{
    public partial class populateConditionsAlliancesAndCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            int conditionId = 0;
            foreach (var item in Enum.GetValues(typeof(ConditionEnum)))
            {
                migrationBuilder.InsertData(
                    table: "Conditions",
                    columns: new[] { "ConditionId", "Name" },
                    values: new object[] { conditionId, item.ToString() });
                conditionId++;
            }

            int allianceId = 0;
            foreach (var item in Enum.GetValues(typeof(AlliancesEnum)))
            {
                var fullName = item.ToString().Replace(" ", "_");
                migrationBuilder.InsertData(
                    table: "Alliances",
                    columns: new[] { "AllianceId", "Name" },
                    values: new object[] { allianceId, fullName });
                allianceId++;
            }

            int nationId = 0;
            foreach (var item in Enum.GetValues(typeof(AlliesEnum)))
            {
                var fullName = item.ToString().Replace(" ", "_");
                migrationBuilder.InsertData(
                    table: "Nations",
                    columns: new[] { "NationId", "Name", "AllianceId" },
                    values: new object[] { nationId, fullName, 0 });
                nationId++;
            }

            foreach (var item in Enum.GetValues(typeof(AxisEnum)))
            {
                var fullName = item.ToString().Replace(" ", "_");
                migrationBuilder.InsertData(
                    table: "Nations",
                    columns: new[] { "NationId", "Name", "AllianceId" },
                    values: new object[] { nationId, fullName, 1 });
                nationId++;
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
