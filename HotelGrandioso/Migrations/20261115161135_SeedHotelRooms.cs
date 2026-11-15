using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelGrandioso.Migrations
{
    /// <inheritdoc />
    public partial class SeedHotelRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Standardrum", "Standard" },
                    { 2, "Lyxig svit på toppvåningen", "Lyxsvit" },
                    { 3, "Exklusiv bröllopssvit på toppvåningen", "Bröllopsvit" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Floor", "PricePerNight", "RoomNumber", "RoomTypeId", "SizeM2" },
                values: new object[,]
                {
                    { 1, 1, 800m, 101, 1, 80.0 },
                    { 2, 1, 800m, 102, 1, 80.0 },
                    { 3, 1, 800m, 103, 1, 80.0 },
                    { 4, 1, 800m, 104, 1, 80.0 },
                    { 5, 1, 800m, 105, 1, 80.0 },
                    { 6, 2, 1000m, 201, 1, 100.0 },
                    { 7, 2, 1000m, 202, 1, 100.0 },
                    { 8, 2, 1000m, 203, 1, 100.0 },
                    { 9, 2, 1000m, 204, 1, 100.0 },
                    { 10, 2, 1000m, 205, 1, 100.0 },
                    { 11, 3, 1200m, 301, 1, 120.0 },
                    { 12, 3, 1200m, 302, 1, 120.0 },
                    { 13, 3, 1200m, 303, 1, 120.0 },
                    { 14, 3, 2800m, 304, 2, 180.0 },
                    { 15, 3, 3500m, 305, 3, 220.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 3);
        }
    }
}
