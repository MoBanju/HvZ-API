using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class Player_Game_Cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 7, 37, 35, 213, DateTimeKind.Utc).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 7, 37, 35, 213, DateTimeKind.Utc).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 7, 37, 35, 213, DateTimeKind.Utc).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 7, 37, 35, 213, DateTimeKind.Utc).AddTicks(1277));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 7, 37, 35, 213, DateTimeKind.Utc).AddTicks(1281));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 7, 37, 35, 213, DateTimeKind.Utc).AddTicks(1281));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 7, 8, 54, 114, DateTimeKind.Utc).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 7, 8, 54, 114, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 7, 8, 54, 114, DateTimeKind.Utc).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 7, 8, 54, 114, DateTimeKind.Utc).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 7, 8, 54, 114, DateTimeKind.Utc).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 7, 8, 54, 114, DateTimeKind.Utc).AddTicks(5370));
        }
    }
}
