using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class coordinates_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Kills",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Kills",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Kills",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Nw_lat",
                table: "Games",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Nw_lng",
                table: "Games",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Se_lat",
                table: "Games",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Se_lng",
                table: "Games",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Kills");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Kills");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Kills");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Nw_lat",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Nw_lng",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Se_lat",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Se_lng",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Games");

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 14, 10, 49, 59, 298, DateTimeKind.Utc).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 14, 10, 49, 59, 298, DateTimeKind.Utc).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 14, 10, 49, 59, 298, DateTimeKind.Utc).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 14, 10, 49, 59, 298, DateTimeKind.Utc).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 14, 10, 49, 59, 298, DateTimeKind.Utc).AddTicks(523));
        }
    }
}
