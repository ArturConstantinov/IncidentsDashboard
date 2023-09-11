using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Incidents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditRowIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelited",
                table: "Users",
                newName: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Users",
                newName: "IsDelited");
        }
    }
}
