using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class seed_squads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerKills",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { true, 2, 2 });

            migrationBuilder.DeleteData(
                table: "PlayerKills",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { false, 2, 3 });

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Squads",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Rank",
                table: "Squad_Members",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(749));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "State",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "State",
                value: 1);

            migrationBuilder.InsertData(
                table: "Kills",
                columns: new[] { "Id", "Description", "GameId", "Latitude", "Longitude", "TimeDeath" },
                values: new object[] { 5, "Fiesty", 4, 58.950000000000003, 5.8099999999999996, new DateTime(2022, 10, 13, 13, 37, 59, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 15, 36, 23, 227, DateTimeKind.Utc).AddTicks(837), new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(837) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 14, 36, 23, 227, DateTimeKind.Utc).AddTicks(844), new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(844) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 17, 36, 23, 227, DateTimeKind.Utc).AddTicks(846), new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(846) });

            migrationBuilder.InsertData(
                table: "PlayerKills",
                columns: new[] { "IsVictim", "KillId", "PlayerId" },
                values: new object[] { false, 2, 1 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IsHuman", "IsPatientZero" },
                values: new object[] { false, true });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BiteCode", "GameId", "IsHuman", "IsPatientZero", "UserId" },
                values: new object[,]
                {
                    { 10, "DontGuessMe", 4, true, false, 4 },
                    { 11, "NoGuess", 4, false, false, 3 },
                    { 12, "DontAtMeBro", 4, false, true, 2 },
                    { 13, "HellomaSma", 2, false, false, 3 }
                });

            migrationBuilder.InsertData(
                table: "Squads",
                columns: new[] { "Id", "GameId", "Name", "is_human" },
                values: new object[,]
                {
                    { 1, 1, "ForeverYoung", true },
                    { 2, 2, "DeadManWalking", false },
                    { 3, 3, "StayinAlive", true },
                    { 4, 3, "StayinDead", false },
                    { 5, 4, "SquadsGalore", true }
                });

            migrationBuilder.InsertData(
                table: "PlayerKills",
                columns: new[] { "IsVictim", "KillId", "PlayerId" },
                values: new object[,]
                {
                    { true, 5, 11 },
                    { false, 5, 12 },
                    { true, 2, 13 }
                });

            migrationBuilder.InsertData(
                table: "Squad_Members",
                columns: new[] { "Id", "GameId", "PlayerId", "Rank", "SquadId" },
                values: new object[,]
                {
                    { 1, 1, 5, "Silver", 1 },
                    { 2, 1, 7, "Gold", 1 },
                    { 3, 2, 1, "GrandMaster", 2 },
                    { 4, 2, 4, "Bronze", 2 },
                    { 5, 3, 9, "GrandWizard", 3 },
                    { 6, 3, 8, "Boss-brain-specialist", 4 },
                    { 7, 3, 2, "Hobo-eater", 4 },
                    { 8, 3, 3, "OG", 4 },
                    { 9, 4, 10, "AllAlone", 5 }
                });

            migrationBuilder.InsertData(
                table: "Squad_Checkins",
                columns: new[] { "Id", "End_time", "GameId", "Latitude", "Longitude", "SquadId", "Squad_MemberId", "Start_time" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 19, 14, 6, 23, 227, DateTimeKind.Utc).AddTicks(964), 1, 60.395299999999999, 5.3150000000000004, 1, 2, new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(964) },
                    { 2, new DateTime(2022, 10, 19, 13, 56, 23, 227, DateTimeKind.Utc).AddTicks(968), 2, 58.984400000000001, 5.6159999999999997, 2, 3, new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(968) },
                    { 3, new DateTime(2022, 10, 19, 14, 31, 23, 227, DateTimeKind.Utc).AddTicks(970), 3, 58.880000000000003, 5.6100000000000003, 3, 5, new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(970) },
                    { 4, new DateTime(2022, 10, 19, 14, 31, 23, 227, DateTimeKind.Utc).AddTicks(972), 3, 58.890000000000001, 5.6299999999999999, 3, 5, new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(971) },
                    { 5, new DateTime(2022, 10, 19, 13, 39, 23, 227, DateTimeKind.Utc).AddTicks(973), 3, 58.890000000000001, 5.6299999999999999, 4, 8, new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(972) },
                    { 6, new DateTime(2022, 10, 19, 14, 31, 23, 227, DateTimeKind.Utc).AddTicks(975), 4, 58.950000000000003, 5.8200000000000003, 4, 9, new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(974) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerKills",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { false, 2, 1 });

            migrationBuilder.DeleteData(
                table: "PlayerKills",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { true, 5, 11 });

            migrationBuilder.DeleteData(
                table: "PlayerKills",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { false, 5, 12 });

            migrationBuilder.DeleteData(
                table: "PlayerKills",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { true, 2, 13 });

            migrationBuilder.DeleteData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Squads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Squads",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Squads",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Squads",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Squads",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Squads",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Rank",
                table: "Squad_Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 19, 12, 20, 18, 171, DateTimeKind.Utc).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 19, 12, 20, 18, 171, DateTimeKind.Utc).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 19, 12, 20, 18, 171, DateTimeKind.Utc).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "State",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "State",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 14, 20, 18, 171, DateTimeKind.Utc).AddTicks(2207), new DateTime(2022, 10, 19, 12, 20, 18, 171, DateTimeKind.Utc).AddTicks(2207) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 13, 20, 18, 171, DateTimeKind.Utc).AddTicks(2215), new DateTime(2022, 10, 19, 12, 20, 18, 171, DateTimeKind.Utc).AddTicks(2214) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 16, 20, 18, 171, DateTimeKind.Utc).AddTicks(2217), new DateTime(2022, 10, 19, 12, 20, 18, 171, DateTimeKind.Utc).AddTicks(2216) });

            migrationBuilder.InsertData(
                table: "PlayerKills",
                columns: new[] { "IsVictim", "KillId", "PlayerId" },
                values: new object[,]
                {
                    { true, 2, 2 },
                    { false, 2, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IsHuman", "IsPatientZero" },
                values: new object[] { true, false });
        }
    }
}
