using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Incidents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeedForIncidents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Id", "AmbitId", "ApplicationType", "CloseDate", "Created", "CreatedBy", "IncidentTypeId", "LastModified", "LastModifiedBy", "OpenDate", "OriginId", "ProblemDescription", "ProblemSummery", "RequestNr", "ScenaryId", "Solution", "SubCause", "Subsystem", "ThirdParty", "ThreatId", "Type", "Urgency" },
                values: new object[] { 1, 3, "Application Type", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "host0000007415837", 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "definition change", "cr", "AAA1", 1, "Request Intervention", "Hight" });
        }
    }
}
