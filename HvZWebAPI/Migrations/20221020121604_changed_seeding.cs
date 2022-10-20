using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class changed_seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squad_Checkins_Squad_Members_Squad_MemberId",
                table: "Squad_Checkins");

            migrationBuilder.RenameColumn(
                name: "is_human",
                table: "Squads",
                newName: "Is_human");

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 14, 16, 4, 223, DateTimeKind.Utc).AddTicks(4578), new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4578) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 16, 4, 223, DateTimeKind.Utc).AddTicks(4585), new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 16, 16, 4, 223, DateTimeKind.Utc).AddTicks(4587), new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4587) });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Description", "End_time", "GameId", "Is_human_visible", "Is_zombie_visible", "Latitude", "Longitude", "Name", "Start_time" },
                values: new object[] { 4, "Bring a pencil!", new DateTime(2022, 10, 20, 16, 16, 4, 223, DateTimeKind.Utc).AddTicks(4589), 1, true, false, 60.395200000000003, 5.3200000000000003, "Crossword", new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 12, 46, 4, 223, DateTimeKind.Utc).AddTicks(4692), new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4692) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 12, 36, 4, 223, DateTimeKind.Utc).AddTicks(4727), new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4726) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 11, 4, 223, DateTimeKind.Utc).AddTicks(4729), new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4728) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 11, 4, 223, DateTimeKind.Utc).AddTicks(4730), new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4730) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 12, 19, 4, 223, DateTimeKind.Utc).AddTicks(4731), new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4731) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 11, 4, 223, DateTimeKind.Utc).AddTicks(4733), new DateTime(2022, 10, 20, 12, 16, 4, 223, DateTimeKind.Utc).AddTicks(4733) });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Squad_Checkins_Squad_Members_Squad_MemberId",
                table: "Squad_Checkins",
                column: "Squad_MemberId",
                principalTable: "Squad_Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squad_Checkins_Squad_Members_Squad_MemberId",
                table: "Squad_Checkins");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Squad_Checkins_Squad_Members_Squad_MemberId",
                table: "Squad_Checkins",
                column: "Squad_MemberId",
                principalTable: "Squad_Members",
                principalColumn: "Id");
        }
    }
}
