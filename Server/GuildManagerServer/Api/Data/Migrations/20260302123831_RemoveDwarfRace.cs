using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildManagerServer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDwarfRace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Instinct", "Name", "Presence", "Spirit", "Strength" },
                values: new object[] { 0, "Tiefling", 1, 1, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Instinct", "Name", "Presence", "Spirit", "Strength" },
                values: new object[] { 1, "Dwarf", 0, 0, 1 });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "Id", "Dexterity", "Health", "Instinct", "Name", "Presence", "Spirit", "Strength" },
                values: new object[] { 4, 0, 10, 0, "Tiefling", 1, 1, 0 });
        }
    }
}
