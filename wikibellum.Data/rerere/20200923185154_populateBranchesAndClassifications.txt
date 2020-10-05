using Microsoft.EntityFrameworkCore.Migrations;
using System;
using wikibellum.Entities.Enums.Countries;

namespace wikibellum.Data.Migrations
{
    public partial class populateBranchesAndClassifications : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
