using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Incidents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChengedSeedAddedForeignKeysScenaryIdThreatId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Scenarios_ScenaryId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Threats_ThreatId",
                table: "Incidents");

            migrationBuilder.InsertData(
                table: "Ambits",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Software" },
                    { 2, "Functionality" },
                    { 3, "Phase" },
                    { 4, "Release" },
                    { 5, "Service" },
                    { 6, "Transmission Channels" },
                    { 7, "CICS" },
                    { 8, "Database" },
                    { 9, "Hardware Host" },
                    { 10, "Hardware Open" },
                    { 11, "Middleware" },
                    { 12, "Networks" },
                    { 13, "Security" },
                    { 14, "Basic Host Software" },
                    { 15, "Open Basic Software" },
                    { 16, "Service Software" },
                    { 17, "Storage" }
                });

            migrationBuilder.InsertData(
                table: "IncidentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Configuration" },
                    { 2, "Software Malfunction" },
                    { 3, "Third Parts" },
                    { 4, "Incorrect Change" },
                    { 5, "Code" },
                    { 6, "Resource Saturation" },
                    { 7, "Insufficient Resources" },
                    { 8, "Hardware Malfunction" },
                    { 9, "Degradation" },
                    { 10, "Block" },
                    { 11, "Accesses" },
                    { 12, "Cyber Attacks" },
                    { 13, "Certificates" },
                    { 14, "Firewall" },
                    { 15, "IDM" },
                    { 16, "Patching" }
                });

            migrationBuilder.InsertData(
                table: "AmbitsToTypes",
                columns: new[] { "AmbitId", "TypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 4 },
                    { 5, 3 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 7 },
                    { 7, 1 },
                    { 7, 8 },
                    { 8, 2 },
                    { 8, 7 },
                    { 8, 8 },
                    { 8, 9 },
                    { 9, 6 },
                    { 9, 7 },
                    { 10, 4 },
                    { 10, 7 },
                    { 10, 9 },
                    { 10, 10 },
                    { 11, 2 },
                    { 11, 4 },
                    { 11, 6 },
                    { 11, 7 },
                    { 12, 4 },
                    { 13, 1 },
                    { 13, 11 },
                    { 13, 12 },
                    { 13, 13 },
                    { 13, 14 },
                    { 13, 15 },
                    { 13, 16 },
                    { 14, 7 },
                    { 15, 6 },
                    { 15, 7 },
                    { 16, 6 },
                    { 16, 9 },
                    { 16, 10 },
                    { 17, 6 }
                });

            migrationBuilder.InsertData(
                table: "OriginsToAmbit",
                columns: new[] { "AmbitId", "OriginId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 5, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 3 },
                    { 10, 3 },
                    { 11, 3 },
                    { 12, 3 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 3 },
                    { 16, 3 },
                    { 17, 3 }
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Scenarios_ScenaryId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Threats_ThreatId",
                table: "Incidents");

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 11, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 11 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 12 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 13 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 14 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 15 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 16 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 14, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 15, 6 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 15, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 16, 6 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 16, 9 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 16, 10 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 17, 6 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 17, 3 });

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
    }
}
