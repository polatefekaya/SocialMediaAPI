using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosanicSocial.Infrastructure.Migrations.Statistics
{
    /// <inheritdoc />
    public partial class reinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Statistics");

            migrationBuilder.CreateTable(
                name: "CommentStatistics",
                schema: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    ReplyCount = table.Column<int>(type: "int", nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostStatistics",
                schema: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: true),
                    CommentCount = table.Column<int>(type: "int", nullable: true),
                    ShareCount = table.Column<int>(type: "int", nullable: true),
                    SeenCount = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostStatistics", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentStatistics",
                schema: "Statistics");

            migrationBuilder.DropTable(
                name: "PostStatistics",
                schema: "Statistics");
        }
    }
}
