using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosanicSocial.Infrastructure.Migrations.UserCritical
{
    /// <inheritdoc />
    public partial class reinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UserCritical");

            migrationBuilder.CreateTable(
                name: "UsersBans",
                schema: "UserCritical",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    IsCritical = table.Column<bool>(type: "bit", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersDangerZones",
                schema: "UserCritical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false),
                    IsPermaBanned = table.Column<bool>(type: "bit", nullable: false),
                    BanCount = table.Column<int>(type: "int", nullable: true),
                    WarningCount = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDangerZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersPermissions",
                schema: "UserCritical",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLastSeenActive = table.Column<bool>(type: "bit", nullable: false),
                    IsActiviyVisible = table.Column<bool>(type: "bit", nullable: false),
                    IsProfileSeenHistoryActive = table.Column<bool>(type: "bit", nullable: false),
                    IsPersonalizedAdsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsRedirectMessagesSentFromStrangersActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPermissions", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UsersWarnings",
                schema: "UserCritical",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WarningCategory = table.Column<int>(type: "int", nullable: false),
                    WarningLevel = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersWarnings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersBans",
                schema: "UserCritical");

            migrationBuilder.DropTable(
                name: "UsersDangerZones",
                schema: "UserCritical");

            migrationBuilder.DropTable(
                name: "UsersPermissions",
                schema: "UserCritical");

            migrationBuilder.DropTable(
                name: "UsersWarnings",
                schema: "UserCritical");
        }
    }
}
