using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class coordinates_renamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Se_lng",
                table: "Games",
                newName: "Sw_lng");

            migrationBuilder.RenameColumn(
                name: "Se_lat",
                table: "Games",
                newName: "Sw_lat");

            migrationBuilder.RenameColumn(
                name: "Nw_lng",
                table: "Games",
                newName: "Ne_lng");

            migrationBuilder.RenameColumn(
                name: "Nw_lat",
                table: "Games",
                newName: "Ne_lat");

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 17, 9, 15, 16, 262, DateTimeKind.Utc).AddTicks(4670));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 17, 9, 15, 16, 262, DateTimeKind.Utc).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 17, 9, 15, 16, 262, DateTimeKind.Utc).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 17, 9, 15, 16, 262, DateTimeKind.Utc).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 17, 9, 15, 16, 262, DateTimeKind.Utc).AddTicks(4653));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sw_lng",
                table: "Games",
                newName: "Se_lng");

            migrationBuilder.RenameColumn(
                name: "Sw_lat",
                table: "Games",
                newName: "Se_lat");

            migrationBuilder.RenameColumn(
                name: "Ne_lng",
                table: "Games",
                newName: "Nw_lng");

            migrationBuilder.RenameColumn(
                name: "Ne_lat",
                table: "Games",
                newName: "Nw_lat");

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 17, 8, 3, 39, 79, DateTimeKind.Utc).AddTicks(1613));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 17, 8, 3, 39, 79, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 17, 8, 3, 39, 79, DateTimeKind.Utc).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 17, 8, 3, 39, 79, DateTimeKind.Utc).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 17, 8, 3, 39, 79, DateTimeKind.Utc).AddTicks(1596));
        }
    }
}
