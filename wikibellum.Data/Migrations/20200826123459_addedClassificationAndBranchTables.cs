using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class addedClassificationAndBranchTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classification",
                table: "Asset");

            migrationBuilder.AlterColumn<int>(
                name: "Condition",
                table: "Asset",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AssetType",
                table: "Asset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "Asset",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    ClassificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    AbbrName = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.ClassificationId);
                    table.ForeignKey(
                        name: "FK_Classifications_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 1, "Naval" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 2, "Air" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Name" },
                values: new object[] { 3, "Land" });

            migrationBuilder.InsertData(
                table: "Classifications",
                columns: new[] { "ClassificationId", "AbbrName", "BranchId", "FullName" },
                values: new object[,]
                {
                    { 21, null, 1, "Sailors" },
                    { 4, null, 2, "Other" },
                    { 5, null, 3, "Infantry" },
                    { 6, null, 3, "Tank" },
                    { 7, null, 3, "Tankette" },
                    { 8, null, 3, "Light_tank" },
                    { 9, null, 3, "Medium_tank" },
                    { 10, null, 3, "Heavy_tank" },
                    { 11, null, 3, "Tank_destroyer" },
                    { 12, null, 3, "Self_propelled_artillery" },
                    { 13, null, 3, "Self_propelled_anti_aircraft_gun" },
                    { 14, null, 3, "Armoured_personnel_carrier" },
                    { 15, null, 3, "Armoured_car" },
                    { 16, null, 3, "Artillery_tractor" },
                    { 17, null, 3, "Amphibious" },
                    { 18, null, 3, "Utility_vehicle" },
                    { 3, null, 2, "Heavy_bomber" },
                    { 19, null, 3, "Rocket_artillery" },
                    { 2, null, 2, "Medium_bomber" },
                    { 37, null, 1, "Landing_craft" },
                    { 22, null, 1, "Aircraft_carrier" },
                    { 23, null, 1, "Battleship" },
                    { 24, null, 1, "Battlecruiser" },
                    { 25, null, 1, "Coastal_defence_ship" },
                    { 26, null, 1, "Monitor" },
                    { 27, null, 1, "Destroyer" },
                    { 28, null, 1, "Frigate" },
                    { 29, null, 1, "Corvette" },
                    { 30, null, 1, "Cruiser" },
                    { 31, null, 1, "Heavy_cruiser" },
                    { 32, null, 1, "Light_cruiser" },
                    { 33, null, 1, "Submarine" },
                    { 34, null, 1, "Mine_layer" },
                    { 35, null, 1, "Patrol_boat" },
                    { 36, null, 1, "Torpedo_boat" },
                    { 1, null, 2, "Fighter" },
                    { 20, null, 3, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ClassificationId",
                table: "Asset",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Classifications_BranchId",
                table: "Classifications",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Classifications_ClassificationId",
                table: "Asset",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "ClassificationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Classifications_ClassificationId",
                table: "Asset");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Asset_ClassificationId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "AssetType",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "Asset");

            migrationBuilder.AlterColumn<int>(
                name: "Condition",
                table: "Asset",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Classification",
                table: "Asset",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
