using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RosanicSocial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumbersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatisticId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roses",
                columns: new[] { "Id", "AuthorId", "AuthorUsername", "Message", "NumbersId", "PostDate", "StatisticId" },
                values: new object[] { new Guid("4c5831ba-251d-4a0b-8e46-1157ae4f739e"), new Guid("efaf57c1-ab42-498b-bed6-1dbb1980a3fd"), "polatsfekaya", "The World is Excellent!", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 7, 0, 53, 19, 599, DateTimeKind.Utc).AddTicks(9689), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roses");
        }
    }
}
