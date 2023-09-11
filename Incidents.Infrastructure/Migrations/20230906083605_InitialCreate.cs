using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Incidents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Origins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Scenarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Threats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDelited = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ambits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OriginId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambits", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Ambits_Origins_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncidentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AmbitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTypes", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_IncidentTypes_Ambits_AmbitId",
                        column: x => x.AmbitId,
                        principalTable: "Ambits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestNr = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Subsystem = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApplicationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Urgency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SubCause = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProblemSummery = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IncidentTypeId = table.Column<int>(type: "int", nullable: true),
                    AmbitId = table.Column<int>(type: "int", nullable: true),
                    OriginId = table.Column<int>(type: "int", nullable: true),
                    ThirdParty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScenaryId = table.Column<int>(type: "int", nullable: true),
                    ThreatId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_IncidentTypes_IncidentTypeId",
                        column: x => x.IncidentTypeId,
                        principalTable: "IncidentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incidents_Scenarios_ScenaryId",
                        column: x => x.ScenaryId,
                        principalTable: "Scenarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incidents_Threats_ThreatId",
                        column: x => x.ThreatId,
                        principalTable: "Threats",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Id", "AmbitId", "ApplicationType", "CloseDate", "Created", "CreatedBy", "IncidentTypeId", "LastModified", "LastModifiedBy", "OpenDate", "OriginId", "ProblemDescription", "ProblemSummery", "RequestNr", "ScenaryId", "Solution", "SubCause", "Subsystem", "ThirdParty", "ThreatId", "Type", "Urgency" },
                values: new object[] { 1, null, "Application Type", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "host00007415837", null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "definition change", "cr", null, null, "Request Intervention", "Hight" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "User that can add, modify and disable other users, change data manually.", "Administrator" },
                    { 2, "User that can import data from a CSV file.", "Operator" },
                    { 3, "User that can can view information about incidents.", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "FullName", "IsEnabled", "LastModified", "LastModifiedBy", "Password", "UserName" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "admin@mail.com", "Admin", true, null, null, "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", "cr00001" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Ambits_Name",
                table: "Ambits",
                column: "Name",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Ambits_OriginId",
                table: "Ambits",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentTypeId",
                table: "Incidents",
                column: "IncidentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_RequestNr",
                table: "Incidents",
                column: "RequestNr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ScenaryId",
                table: "Incidents",
                column: "ScenaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ThreatId",
                table: "Incidents",
                column: "ThreatId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypes_AmbitId",
                table: "IncidentTypes",
                column: "AmbitId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypes_Name",
                table: "IncidentTypes",
                column: "Name",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Origins_Name",
                table: "Origins",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "IncidentTypes");

            migrationBuilder.DropTable(
                name: "Scenarios");

            migrationBuilder.DropTable(
                name: "Threats");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ambits");

            migrationBuilder.DropTable(
                name: "Origins");
        }
    }
}
