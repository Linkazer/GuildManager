using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildManagerServer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Basic clothes" });

            migrationBuilder.InsertData(
                table: "Job",
                columns: new[] { "Id", "Dexterity", "HealthByLevel", "Instinct", "Name", "Presence", "Spirit", "Strength" },
                values: new object[] { 1, 0, 3, 0, "Fighter", 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "Id", "Dexterity", "Health", "Instinct", "Name", "Presence", "Spirit", "Strength" },
                values: new object[] { 1, 0, 10, 0, "Human", 0, 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
