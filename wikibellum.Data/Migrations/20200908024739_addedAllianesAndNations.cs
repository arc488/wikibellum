using Microsoft.EntityFrameworkCore.Migrations;

namespace wikibellum.Data.Migrations
{
    public partial class addedAllianesAndNations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_EventParticipants_EventParticipantId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_EventParticipants_EventParticipantId1",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Events_EventId",
                table: "EventParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventParticipants",
                table: "EventParticipants");

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "ClassificationId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventParticipants");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "EventParticipants");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Locations",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Events",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EventParticipantId",
                table: "EventParticipants",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "NationId",
                table: "EventParticipants",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventParticipants",
                table: "EventParticipants",
                column: "EventParticipantId");

            migrationBuilder.CreateTable(
                name: "Alliances",
                columns: table => new
                {
                    AllianceId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alliances", x => x.AllianceId);
                });

            migrationBuilder.CreateTable(
                name: "Nations",
                columns: table => new
                {
                    NationId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AllianceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nations", x => x.NationId);
                    table.ForeignKey(
                        name: "FK_Nations_Alliances_AllianceId",
                        column: x => x.AllianceId,
                        principalTable: "Alliances",
                        principalColumn: "AllianceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_NationId",
                table: "EventParticipants",
                column: "NationId");

            migrationBuilder.CreateIndex(
                name: "IX_Nations_AllianceId",
                table: "Nations",
                column: "AllianceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_EventParticipants_EventParticipantId",
                table: "Asset",
                column: "EventParticipantId",
                principalTable: "EventParticipants",
                principalColumn: "EventParticipantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_EventParticipants_EventParticipantId1",
                table: "Asset",
                column: "EventParticipantId1",
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

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Nations_NationId",
                table: "EventParticipants",
                column: "NationId",
                principalTable: "Nations",
                principalColumn: "NationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_EventParticipants_EventParticipantId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_EventParticipants_EventParticipantId1",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Events_EventId",
                table: "EventParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Nations_NationId",
                table: "EventParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Nations");

            migrationBuilder.DropTable(
                name: "Alliances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventParticipants",
                table: "EventParticipants");

            migrationBuilder.DropIndex(
                name: "IX_EventParticipants_NationId",
                table: "EventParticipants");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventParticipantId",
                table: "EventParticipants");

            migrationBuilder.DropColumn(
                name: "NationId",
                table: "EventParticipants");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventParticipants",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EventParticipants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventParticipants",
                table: "EventParticipants",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_EventParticipants_EventParticipantId",
                table: "Asset",
                column: "EventParticipantId",
                principalTable: "EventParticipants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_EventParticipants_EventParticipantId1",
                table: "Asset",
                column: "EventParticipantId1",
                principalTable: "EventParticipants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Events_EventId",
                table: "EventParticipants",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
