using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class Player_Kill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Players_KillerId",
                table: "Kills");

            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Players_VictimId",
                table: "Kills");

            migrationBuilder.DropIndex(
                name: "IX_Kills_KillerId",
                table: "Kills");

            migrationBuilder.DropIndex(
                name: "IX_Kills_VictimId",
                table: "Kills");

            migrationBuilder.DropColumn(
                name: "KillerId",
                table: "Kills");

            migrationBuilder.DropColumn(
                name: "VictimId",
                table: "Kills");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BiteCode",
                table: "Players",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PlayerKill",
                columns: table => new
                {
                    IsVictim = table.Column<bool>(type: "bit", nullable: false),
                    KillId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerKill", x => new { x.PlayerId, x.KillId, x.IsVictim });
                    table.ForeignKey(
                        name: "FK_PlayerKill_Kills_KillId",
                        column: x => x.KillId,
                        principalTable: "Kills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerKill_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "PlayerKill",
                columns: new[] { "IsVictim", "KillId", "PlayerId" },
                values: new object[,]
                {
                    { false, 1, 1 },
                    { true, 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                column: "BiteCode",
                value: "Helloma");

            migrationBuilder.CreateIndex(
                name: "IX_Players_BiteCode",
                table: "Players",
                column: "BiteCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerKill_KillId",
                table: "PlayerKill",
                column: "KillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerKill");

            migrationBuilder.DropIndex(
                name: "IX_Players_BiteCode",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "BiteCode",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "KillerId",
                table: "Kills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VictimId",
                table: "Kills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 4, 12, 0, 8, 394, DateTimeKind.Local).AddTicks(6495));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 4, 12, 0, 8, 394, DateTimeKind.Local).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 4, 12, 0, 8, 394, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "KillerId", "TimeDeath", "VictimId" },
                values: new object[] { 2, new DateTime(2022, 10, 4, 12, 0, 8, 394, DateTimeKind.Local).AddTicks(6375), 1 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "KillerId", "TimeDeath", "VictimId" },
                values: new object[] { 4, new DateTime(2022, 10, 4, 12, 0, 8, 394, DateTimeKind.Local).AddTicks(6437), 3 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "KillerId", "TimeDeath", "VictimId" },
                values: new object[] { 2, new DateTime(2022, 10, 4, 12, 0, 8, 394, DateTimeKind.Local).AddTicks(6442), 4 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                column: "BiteCode",
                value: "Hello");

            migrationBuilder.CreateIndex(
                name: "IX_Kills_KillerId",
                table: "Kills",
                column: "KillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Kills_VictimId",
                table: "Kills",
                column: "VictimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kills_Players_KillerId",
                table: "Kills",
                column: "KillerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kills_Players_VictimId",
                table: "Kills",
                column: "VictimId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
