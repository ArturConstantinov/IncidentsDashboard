using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Incidents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "FullName", "IsEnabled", "LastModified", "LastModifiedBy", "Password", "UserName" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "user@mail.com", "User", true, null, null, "04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb", "cr00002" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 3, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
