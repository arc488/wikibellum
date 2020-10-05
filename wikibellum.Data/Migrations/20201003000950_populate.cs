using Microsoft.EntityFrameworkCore.Migrations;
using System;
using wikibellum.Entities.Enums;
using wikibellum.Entities.Enums.Countries;

namespace wikibellum.Data.Migrations
{
    public partial class populate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            int branchId = 0;
            foreach (var item in Enum.GetValues(typeof(BranchEnum)))
            {
                migrationBuilder.InsertData(
                    table: "Branches",
                    columns: new[] { "BranchId", "Name" },
                    values: new object[] { branchId, item.ToString() });
                branchId++;
            }

            int classificationId = 0;

            foreach (var item in Enum.GetValues(typeof(LandEnum)))
            {
                var fullName = item.ToString().Replace(" ", "_");
                migrationBuilder.InsertData(
                    table: "Classifications",
                    columns: new[] { "ClassificationId", "FullName", "AbbrName", "BranchId" },
                    values: new object[] { classificationId, fullName, "", 1 });
                classificationId++;
            }

            foreach (var item in Enum.GetValues(typeof(NavalEnum)))
            {
                var fullName = item.ToString().Replace(" ", "_");
                migrationBuilder.InsertData(
                    table: "Classifications",
                    columns: new[] { "ClassificationId", "FullName", "AbbrName", "BranchId" },
                    values: new object[] { classificationId, fullName, "", 2 });
                classificationId++;
            }

            foreach (var item in Enum.GetValues(typeof(AirEnum)))
            {
                var fullName = item.ToString().Replace(" ", "_");
                migrationBuilder.InsertData(
                    table: "Classifications",
                    columns: new[] { "ClassificationId", "FullName", "AbbrName", "BranchId" },
                    values: new object[] { classificationId, fullName, "", 3 });
                classificationId++;
            }

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

            var organizationId = 1;
            foreach (var item in Enum.GetValues(typeof(LandOrganization)))
            {
                var fullName = item.ToString().Replace("_", " ");
                migrationBuilder.InsertData(
                    table: "Organizations",
                    columns: new[] { "OrganizationId", "Name", "BranchId" },
                    values: new object[] { organizationId, fullName, 1 });
                organizationId++;
            }

            foreach (var item in Enum.GetValues(typeof(NavyOrganization)))
            {
                var fullName = item.ToString().Replace("_", " ");
                migrationBuilder.InsertData(
                    table: "Organizations",
                    columns: new[] { "OrganizationId", "Name", "BranchId" },
                    values: new object[] { organizationId, fullName, 2 });
                organizationId++;
            }

            foreach (var item in Enum.GetValues(typeof(AirOrganization)))
            {
                var fullName = item.ToString().Replace("_", " ");
                migrationBuilder.InsertData(
                    table: "Organizations",
                    columns: new[] { "OrganizationId", "Name", "BranchId" },
                    values: new object[] { organizationId, fullName, 3 });
                organizationId++;
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
