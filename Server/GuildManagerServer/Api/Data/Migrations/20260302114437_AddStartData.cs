using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuildManagerServer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStartData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Clothe");

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Leather armor" },
                    { 3, "Chain mail" },
                    { 4, "Plate armor" }
                });

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 1,
                column: "Strength",
                value: 1);

            migrationBuilder.InsertData(
                table: "Job",
                columns: new[] { "Id", "Dexterity", "HealthByLevel", "Instinct", "Name", "Presence", "Spirit", "Strength" },
                values: new object[,]
                {
                    { 2, 0, 2, 0, "Bard", 1, 0, 0 },
                    { 3, 0, 1, 0, "Mage", 0, 1, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Instinct", "Presence" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "Id", "Dexterity", "Health", "Instinct", "Name", "Presence", "Spirit", "Strength" },
                values: new object[,]
                {
                    { 2, 1, 10, 0, "Elf", 0, 1, 0 },
                    { 3, 0, 10, 0, "Tiefling", 1, 1, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Basic clothes");

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 1,
                column: "Strength",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Instinct", "Presence" },
                values: new object[] { 0, 0 });
        }
    }
}
