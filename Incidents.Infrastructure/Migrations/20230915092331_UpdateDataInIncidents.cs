using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Incidents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataInIncidents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmbitId", "IncidentTypeId", "OriginId", "ScenaryId", "ThirdParty", "ThreatId" },
                values: new object[] { 3, 1, 1, 1, "AAA1", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmbitId", "IncidentTypeId", "OriginId", "ScenaryId", "ThirdParty", "ThreatId" },
                values: new object[] { null, null, null, null, null, null });
        }
    }
}
