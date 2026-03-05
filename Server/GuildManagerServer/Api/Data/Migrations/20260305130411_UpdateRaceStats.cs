using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildManagerServer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRaceStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 2,
                column: "Health",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 3,
                column: "Health",
                value: 8);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 2,
                column: "Health",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 3,
                column: "Health",
                value: 10);
        }
    }
}
