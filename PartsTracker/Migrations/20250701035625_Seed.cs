using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PartsTracker.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartNumber", "Description", "LastStockTake", "LocationCode", "QuantityOnHand" },
                values: new object[,]
                {
                    { "P_001", "Screen with atleast 2.5 HDMI Ports", new DateTime(2025, 6, 30, 8, 0, 0, 0, DateTimeKind.Utc), "pta-2", 31 },
                    { "P_002", "Mouse that is both wireless, and not", new DateTime(2025, 6, 30, 8, 0, 0, 0, DateTimeKind.Utc), "pta-1", 29 },
                    { "P_003", "Keyboard with 16 additional keys", new DateTime(2025, 6, 30, 8, 0, 0, 0, DateTimeKind.Utc), "jhb-1", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartNumber",
                keyValue: "P_001");

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartNumber",
                keyValue: "P_002");

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "PartNumber",
                keyValue: "P_003");
        }
    }
}
