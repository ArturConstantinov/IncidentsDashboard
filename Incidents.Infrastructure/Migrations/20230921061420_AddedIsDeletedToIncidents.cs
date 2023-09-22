using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Incidents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsDeletedToIncidents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Incidents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Incidents");
        }
    }
}
