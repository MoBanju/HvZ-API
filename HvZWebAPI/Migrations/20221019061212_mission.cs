using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class mission : Migration
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

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Is_human_visible = table.Column<bool>(type: "bit", nullable: false),
                    Is_zombie_visible = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Start_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 19, 6, 12, 11, 682, DateTimeKind.Utc).AddTicks(901));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 19, 6, 12, 11, 682, DateTimeKind.Utc).AddTicks(908));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 19, 6, 12, 11, 682, DateTimeKind.Utc).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 19, 6, 12, 11, 682, DateTimeKind.Utc).AddTicks(851));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 19, 6, 12, 11, 682, DateTimeKind.Utc).AddTicks(858));

            migrationBuilder.CreateIndex(
                name: "IX_Missions_GameId",
                table: "Missions",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Missions");

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
    }
}
