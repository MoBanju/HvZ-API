using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class seed_mission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Missions",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Missions",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1166));

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Description", "End_time", "GameId", "Is_human_visible", "Is_zombie_visible", "Latitude", "Longitude", "Name", "Start_time" },
                values: new object[,]
                {
                    { 1, "Touch your head!", new DateTime(2022, 10, 19, 9, 48, 48, 839, DateTimeKind.Utc).AddTicks(1244), 3, true, false, 58.880000000000003, 5.6100000000000003, "Head here", new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1243) },
                    { 2, "Touch your toes!", new DateTime(2022, 10, 19, 8, 48, 48, 839, DateTimeKind.Utc).AddTicks(1253), 2, true, false, 58.983899999999998, 5.6139999999999999, "Take a trip", new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1253) },
                    { 3, "Jump up on the table and do a zombie dance!", new DateTime(2022, 10, 19, 11, 48, 48, 839, DateTimeKind.Utc).AddTicks(1256), 2, false, true, 58.983980000000003, 5.617, "JigglyBrains", new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1256) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Missions");

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
        }
    }
}
