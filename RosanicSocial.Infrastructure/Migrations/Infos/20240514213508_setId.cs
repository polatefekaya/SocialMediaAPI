using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosanicSocial.Infrastructure.Migrations.Infos
{
    /// <inheritdoc />
    public partial class setId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Infos");

            migrationBuilder.CreateTable(
                name: "BaseInfos",
                schema: "Infos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostCount = table.Column<int>(type: "int", nullable: false),
                    FollowerCount = table.Column<int>(type: "int", nullable: true),
                    FollowingCount = table.Column<int>(type: "int", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailedInfos",
                schema: "Infos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseInfos",
                schema: "Infos");

            migrationBuilder.DropTable(
                name: "DetailedInfos",
                schema: "Infos");
        }
    }
}
