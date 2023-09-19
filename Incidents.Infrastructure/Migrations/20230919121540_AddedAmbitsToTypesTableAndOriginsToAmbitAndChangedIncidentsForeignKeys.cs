using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Incidents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAmbitsToTypesTableAndOriginsToAmbitAndChangedIncidentsForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ambits_Origins_OriginId",
                table: "Ambits");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Scenarios_ScenaryId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Threats_ThreatId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentTypes_Ambits_AmbitId",
                table: "IncidentTypes");

            migrationBuilder.DropIndex(
                name: "IX_IncidentTypes_AmbitId",
                table: "IncidentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Ambits_OriginId",
                table: "Ambits");

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ambits",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DropColumn(
                name: "AmbitId",
                table: "IncidentTypes");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "Ambits");

            migrationBuilder.AlterColumn<int>(
                name: "ThreatId",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThirdParty",
                table: "Incidents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subsystem",
                table: "Incidents",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ScenaryId",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OriginId",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IncidentTypeId",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AmbitId",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AmbitsToTypes",
                columns: table => new
                {
                    AmbitId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmbitsToTypes", x => new { x.AmbitId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_AmbitsToTypes_Ambits_AmbitId",
                        column: x => x.AmbitId,
                        principalTable: "Ambits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AmbitsToTypes_IncidentTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "IncidentTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OriginsToAmbit",
                columns: table => new
                {
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    AmbitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OriginsToAmbit", x => new { x.OriginId, x.AmbitId });
                    table.ForeignKey(
                        name: "FK_OriginsToAmbit_Ambits_AmbitId",
                        column: x => x.AmbitId,
                        principalTable: "Ambits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OriginsToAmbit_Origins_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origins",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestNr",
                value: "host0000007415837");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_AmbitId",
                table: "Incidents",
                column: "AmbitId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_OriginId",
                table: "Incidents",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_AmbitsToTypes_TypeId",
                table: "AmbitsToTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OriginsToAmbit_AmbitId",
                table: "OriginsToAmbit",
                column: "AmbitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Ambits_AmbitId",
                table: "Incidents",
                column: "AmbitId",
                principalTable: "Ambits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Origins_OriginId",
                table: "Incidents",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Scenarios_ScenaryId",
                table: "Incidents",
                column: "ScenaryId",
                principalTable: "Scenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Threats_ThreatId",
                table: "Incidents",
                column: "ThreatId",
                principalTable: "Threats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Ambits_AmbitId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Origins_OriginId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Scenarios_ScenaryId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Threats_ThreatId",
                table: "Incidents");

            migrationBuilder.DropTable(
                name: "AmbitsToTypes");

            migrationBuilder.DropTable(
                name: "OriginsToAmbit");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_AmbitId",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_OriginId",
                table: "Incidents");

            migrationBuilder.AddColumn<int>(
                name: "AmbitId",
                table: "IncidentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ThreatId",
                table: "Incidents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ThirdParty",
                table: "Incidents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Subsystem",
                table: "Incidents",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<int>(
                name: "ScenaryId",
                table: "Incidents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OriginId",
                table: "Incidents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IncidentTypeId",
                table: "Incidents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AmbitId",
                table: "Incidents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "Ambits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Ambits",
                columns: new[] { "Id", "Name", "OriginId" },
                values: new object[,]
                {
                    { 1, "Software", 1 },
                    { 2, "Functionality", 1 },
                    { 3, "Phase", 1 },
                    { 4, "Release", 1 },
                    { 5, "Service", 2 },
                    { 6, "Functionality", 2 },
                    { 7, "Software", 2 },
                    { 8, "Transmission Channels", 3 },
                    { 9, "CICS", 3 },
                    { 10, "Database", 3 },
                    { 11, "Phase", 1 },
                    { 12, "Hardware Host", 3 },
                    { 13, "Hardware Open", 3 },
                    { 14, "Middleware", 3 },
                    { 15, "Networks", 3 },
                    { 16, "Security", 3 },
                    { 17, "Software", 3 },
                    { 18, "Basic Host Software", 3 },
                    { 19, "Open Basic Software", 3 },
                    { 20, "Service Software", 3 },
                    { 21, "Storage", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestNr",
                value: "host00007415837");

            migrationBuilder.InsertData(
                table: "IncidentTypes",
                columns: new[] { "Id", "AmbitId", "Name" },
                values: new object[,]
                {
                    { 1, 3, "Configuration" },
                    { 2, 3, "Software Malfunction" },
                    { 3, 11, "Configuration" },
                    { 4, 11, "Software Malfunction" },
                    { 5, 2, "Software Malfunction" },
                    { 6, 6, "Third Parts" },
                    { 7, 4, "Incorrect Change" },
                    { 8, 1, "Incorrect Change" },
                    { 9, 1, "Code" },
                    { 10, 1, "Configuration" },
                    { 11, 1, "Resource Saturation" },
                    { 12, 7, "Third Parts" },
                    { 13, 17, "Insufficient Resources" },
                    { 14, 5, "Third Parts" },
                    { 15, 8, "Software Malfunction" },
                    { 16, 8, "Insufficient Resources" },
                    { 17, 8, "Configuration" },
                    { 18, 9, "Hardware Malfunction" },
                    { 19, 9, "Configuration" },
                    { 20, 10, "Degradation" },
                    { 21, 10, "Hardware Malfunction" },
                    { 22, 10, "Software Malfunction" },
                    { 23, 10, "Insufficient Resources" },
                    { 24, 12, "Insufficient Resources" },
                    { 25, 12, "Resource Saturation" },
                    { 26, 13, "Incorrect Change" },
                    { 27, 13, "Block" },
                    { 28, 13, "Degradation" },
                    { 29, 13, "Insufficient Resources" },
                    { 30, 14, "Incorrect Change" },
                    { 31, 14, "Software Malfunction" },
                    { 32, 14, "Insufficient Resources" },
                    { 33, 14, "Resource Saturation" },
                    { 34, 15, "Incorrect Change" },
                    { 35, 16, "Accesses" },
                    { 36, 16, "Cyber Attacks" },
                    { 37, 16, "Certificates" },
                    { 38, 16, "Configuration" },
                    { 39, 16, "Firewall" },
                    { 40, 16, "IDM" },
                    { 41, 16, "Patching" },
                    { 42, 18, "Insufficient Resources" },
                    { 43, 19, "Insufficient Resources" },
                    { 44, 19, "Resource Saturation" },
                    { 45, 20, "Block" },
                    { 46, 20, "Degradation" },
                    { 47, 20, "Resource Saturation" },
                    { 48, 21, "Resource Saturation" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypes_AmbitId",
                table: "IncidentTypes",
                column: "AmbitId");

            migrationBuilder.CreateIndex(
                name: "IX_Ambits_OriginId",
                table: "Ambits",
                column: "OriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ambits_Origins_OriginId",
                table: "Ambits",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Scenarios_ScenaryId",
                table: "Incidents",
                column: "ScenaryId",
                principalTable: "Scenarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Threats_ThreatId",
                table: "Incidents",
                column: "ThreatId",
                principalTable: "Threats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentTypes_Ambits_AmbitId",
                table: "IncidentTypes",
                column: "AmbitId",
                principalTable: "Ambits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
