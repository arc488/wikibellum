using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class addNAToOrganizationAtIndex0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationId", "Singular", "BranchId", "Plural" },
                values: new object[] { 0, "N/A", 0, "N/A" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
