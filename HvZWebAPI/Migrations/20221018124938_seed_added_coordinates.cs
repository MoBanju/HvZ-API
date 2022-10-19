using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class seed_added_coordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KeyCloakId",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 60.395527999999999, 5.320989, 60.395122999999998, 5.3146870000000002 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 58.984830000000002, 5.619021, 58.983857, 5.613486 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 58.895001999999998, 5.6449809999999996, 58.870288000000002, 5.6021359999999998 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 58.964326999999997, 5.8464679999999998, 58.940604999999998, 5.8035119999999996 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Latitude", "Longitude", "TimeDeath" },
                values: new object[] { "CAMPER!!", 58.983899999999998, 5.6150000000000002, new DateTime(2022, 10, 18, 12, 49, 37, 921, DateTimeKind.Utc).AddTicks(5392) });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "GameId", "Latitude", "Longitude", "TimeDeath" },
                values: new object[] { "GET HIM!", 2, 58.984172999999998, 5.6151669999999996, new DateTime(2022, 10, 18, 12, 49, 37, 921, DateTimeKind.Utc).AddTicks(5398) });

            migrationBuilder.InsertData(
                table: "Kills",
                columns: new[] { "Id", "Description", "GameId", "Latitude", "Longitude", "TimeDeath" },
                values: new object[,]
                {
                    { 3, "", 3, 58.885641999999997, 5.6335850000000001, new DateTime(2022, 10, 18, 12, 49, 37, 921, DateTimeKind.Utc).AddTicks(5399) },
                    { 4, "", 3, 58.893352999999998, 5.6372780000000002, new DateTime(2022, 10, 18, 12, 49, 37, 921, DateTimeKind.Utc).AddTicks(5400) }
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsHuman",
                value: true);

            migrationBuilder.InsertData(
                table: "PlayerKills",
                columns: new[] { "IsVictim", "KillId", "PlayerId" },
                values: new object[,]
                {
                    { true, 4, 2 },
                    { false, 3, 3 },
                    { true, 3, 8 },
                    { false, 4, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerKills",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { true, 4, 2 });

            migrationBuilder.DeleteData(
                table: "PlayerKills",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { false, 3, 3 });

            migrationBuilder.DeleteData(
                table: "PlayerKills",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { true, 3, 8 });

            migrationBuilder.DeleteData(
                table: "PlayerKills",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { false, 4, 8 });

            migrationBuilder.DeleteData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "KeyCloakId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 0.0, 0.0, 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 0.0, 0.0, 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 0.0, 0.0, 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 0.0, 0.0, 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Latitude", "Longitude", "TimeDeath" },
                values: new object[] { null, null, null, new DateTime(2022, 10, 17, 9, 15, 16, 262, DateTimeKind.Utc).AddTicks(4650) });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "GameId", "Latitude", "Longitude", "TimeDeath" },
                values: new object[] { null, 3, null, null, new DateTime(2022, 10, 17, 9, 15, 16, 262, DateTimeKind.Utc).AddTicks(4653) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsHuman",
                value: false);
        }
    }
}
