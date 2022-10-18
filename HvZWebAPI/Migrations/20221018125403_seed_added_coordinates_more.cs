using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class seed_added_coordinates_more : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 18, 12, 54, 3, 435, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 18, 12, 54, 3, 435, DateTimeKind.Utc).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 18, 12, 54, 3, 435, DateTimeKind.Utc).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 13, 13, 37, 59, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 14, 13, 37, 59, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 13, 13, 37, 59, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 14, 13, 37, 59, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsHuman",
                value: false);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsHuman",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 18, 12, 49, 37, 921, DateTimeKind.Utc).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 18, 12, 49, 37, 921, DateTimeKind.Utc).AddTicks(5422));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 18, 12, 49, 37, 921, DateTimeKind.Utc).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 18, 12, 49, 37, 921, DateTimeKind.Utc).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 18, 12, 49, 37, 921, DateTimeKind.Utc).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 18, 12, 49, 37, 921, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 18, 12, 49, 37, 921, DateTimeKind.Utc).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsHuman",
                value: true);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsHuman",
                value: true);
        }
    }
}
