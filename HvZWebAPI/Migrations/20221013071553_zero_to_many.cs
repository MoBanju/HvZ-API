using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class zero_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 13, 7, 15, 52, 456, DateTimeKind.Utc).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 13, 7, 15, 52, 456, DateTimeKind.Utc).AddTicks(3552));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ChatTime", "GameId" },
                values: new object[] { new DateTime(2022, 10, 13, 7, 15, 52, 456, DateTimeKind.Utc).AddTicks(3555), 3 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 13, 7, 15, 52, 456, DateTimeKind.Utc).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 13, 7, 15, 52, 456, DateTimeKind.Utc).AddTicks(3495));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 13, 6, 36, 55, 275, DateTimeKind.Utc).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 13, 6, 36, 55, 275, DateTimeKind.Utc).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ChatTime", "GameId" },
                values: new object[] { new DateTime(2022, 10, 13, 6, 36, 55, 275, DateTimeKind.Utc).AddTicks(1410), 2 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 13, 6, 36, 55, 275, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 13, 6, 36, 55, 275, DateTimeKind.Utc).AddTicks(1353));

            migrationBuilder.InsertData(
                table: "Kills",
                columns: new[] { "Id", "GameId", "TimeDeath" },
                values: new object[,]
                {
                    { 3, 2, new DateTime(2022, 10, 13, 6, 36, 55, 275, DateTimeKind.Utc).AddTicks(1355) },
                    { 4, 3, new DateTime(2022, 10, 13, 6, 36, 55, 275, DateTimeKind.Utc).AddTicks(1357) }
                });
        }
    }
}
