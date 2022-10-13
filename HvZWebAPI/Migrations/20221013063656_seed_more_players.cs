using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class seed_more_players : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                column: "ChatTime",
                value: new DateTime(2022, 10, 13, 6, 36, 55, 275, DateTimeKind.Utc).AddTicks(1410));

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

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 13, 6, 36, 55, 275, DateTimeKind.Utc).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 13, 6, 36, 55, 275, DateTimeKind.Utc).AddTicks(1357));

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BiteCode", "GameId", "IsHuman", "IsPatientZero", "UserId" },
                values: new object[,]
                {
                    { 5, "Five", 1, true, false, 1 },
                    { 6, "Six", 1, true, false, 3 },
                    { 7, "Seven", 1, true, false, 4 },
                    { 8, "Eight", 3, true, false, 1 },
                    { 9, "Nine", 2, true, false, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2319));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2320));
        }
    }
}
