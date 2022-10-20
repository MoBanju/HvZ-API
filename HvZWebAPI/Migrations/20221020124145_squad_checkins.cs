using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class squad_checkins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_human",
                table: "Squads",
                newName: "Is_human");

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 14, 41, 45, 384, DateTimeKind.Utc).AddTicks(3924), new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(3923) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 41, 45, 384, DateTimeKind.Utc).AddTicks(3934), new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(3933) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 16, 41, 45, 384, DateTimeKind.Utc).AddTicks(3936), new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(3936) });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Description", "End_time", "GameId", "Is_human_visible", "Is_zombie_visible", "Latitude", "Longitude", "Name", "Start_time" },
                values: new object[] { 4, "Bring a pencil!", new DateTime(2022, 10, 20, 16, 41, 45, 384, DateTimeKind.Utc).AddTicks(3938), 1, true, false, 60.395200000000003, 5.3200000000000003, "Crossword", new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(3938) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 11, 45, 384, DateTimeKind.Utc).AddTicks(4069), new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(4069) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 1, 45, 384, DateTimeKind.Utc).AddTicks(4073), new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(4073) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 36, 45, 384, DateTimeKind.Utc).AddTicks(4075), new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(4075) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 36, 45, 384, DateTimeKind.Utc).AddTicks(4077), new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(4076) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 12, 44, 45, 384, DateTimeKind.Utc).AddTicks(4078), new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 36, 45, 384, DateTimeKind.Utc).AddTicks(4080), new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rank",
                value: "Boss");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rank",
                value: "Goon");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rank",
                value: "Boss");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rank",
                value: "Goon");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rank",
                value: "Boss");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rank",
                value: "Goon");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rank",
                value: "Goon");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rank",
                value: "Boss");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rank",
                value: "Boss");

            migrationBuilder.InsertData(
                table: "Squads",
                columns: new[] { "Id", "GameId", "Is_human", "Name" },
                values: new object[] { 6, 2, true, "IOnceLived" });

            migrationBuilder.InsertData(
                table: "Squad_Members",
                columns: new[] { "Id", "GameId", "PlayerId", "Rank", "SquadId" },
                values: new object[] { 10, 2, 13, "Boss", 6 });

            migrationBuilder.InsertData(
                table: "Squad_Members",
                columns: new[] { "Id", "GameId", "PlayerId", "Rank", "SquadId" },
                values: new object[] { 11, 2, 4, "Goon", 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Squads",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameColumn(
                name: "Is_human",
                table: "Squads",
                newName: "is_human");

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

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 14, 6, 23, 227, DateTimeKind.Utc).AddTicks(964), new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 13, 56, 23, 227, DateTimeKind.Utc).AddTicks(968), new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(968) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 14, 31, 23, 227, DateTimeKind.Utc).AddTicks(970), new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(970) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 14, 31, 23, 227, DateTimeKind.Utc).AddTicks(972), new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(971) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 13, 39, 23, 227, DateTimeKind.Utc).AddTicks(973), new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(972) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 14, 31, 23, 227, DateTimeKind.Utc).AddTicks(975), new DateTime(2022, 10, 19, 13, 36, 23, 227, DateTimeKind.Utc).AddTicks(974) });

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rank",
                value: "Silver");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rank",
                value: "Gold");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rank",
                value: "GrandMaster");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rank",
                value: "Bronze");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rank",
                value: "GrandWizard");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rank",
                value: "Boss-brain-specialist");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rank",
                value: "Hobo-eater");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rank",
                value: "OG");

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rank",
                value: "AllAlone");
        }
    }
}
