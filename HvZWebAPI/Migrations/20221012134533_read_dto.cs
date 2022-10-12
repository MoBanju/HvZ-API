using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class read_dto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerKill_Kills_KillId",
                table: "PlayerKill");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerKill_Players_PlayerId",
                table: "PlayerKill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerKill",
                table: "PlayerKill");

            migrationBuilder.RenameTable(
                name: "PlayerKill",
                newName: "PlayerKills");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerKill_KillId",
                table: "PlayerKills",
                newName: "IX_PlayerKills_KillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerKills",
                table: "PlayerKills",
                columns: new[] { "PlayerId", "KillId", "IsVictim" });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 13, 45, 33, 362, DateTimeKind.Utc).AddTicks(7250));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 13, 45, 33, 362, DateTimeKind.Utc).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 13, 45, 33, 362, DateTimeKind.Utc).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 45, 33, 362, DateTimeKind.Utc).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 45, 33, 362, DateTimeKind.Utc).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 45, 33, 362, DateTimeKind.Utc).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 45, 33, 362, DateTimeKind.Utc).AddTicks(7235));

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerKills_Kills_KillId",
                table: "PlayerKills",
                column: "KillId",
                principalTable: "Kills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerKills_Players_PlayerId",
                table: "PlayerKills",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerKills_Kills_KillId",
                table: "PlayerKills");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerKills_Players_PlayerId",
                table: "PlayerKills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerKills",
                table: "PlayerKills");

            migrationBuilder.RenameTable(
                name: "PlayerKills",
                newName: "PlayerKill");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerKills_KillId",
                table: "PlayerKill",
                newName: "IX_PlayerKill_KillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerKill",
                table: "PlayerKill",
                columns: new[] { "PlayerId", "KillId", "IsVictim" });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 13, 19, 48, 490, DateTimeKind.Utc).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 13, 19, 48, 490, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 13, 19, 48, 490, DateTimeKind.Utc).AddTicks(6078));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 19, 48, 490, DateTimeKind.Utc).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 19, 48, 490, DateTimeKind.Utc).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 19, 48, 490, DateTimeKind.Utc).AddTicks(6052));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 19, 48, 490, DateTimeKind.Utc).AddTicks(6053));

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerKill_Kills_KillId",
                table: "PlayerKill",
                column: "KillId",
                principalTable: "Kills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerKill_Players_PlayerId",
                table: "PlayerKill",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
