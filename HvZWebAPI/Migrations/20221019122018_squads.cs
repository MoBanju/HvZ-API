using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class squads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Missions",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Missions",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SquadId",
                table: "Chats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Squads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_human = table.Column<bool>(type: "bit", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Squads_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Squad_Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    SquadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squad_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Squad_Members_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Squad_Members_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Squad_Members_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Squad_Checkins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    SquadId = table.Column<int>(type: "int", nullable: false),
                    Squad_MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squad_Checkins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Squad_Checkins_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Squad_Checkins_Squad_Members_Squad_MemberId",
                        column: x => x.Squad_MemberId,
                        principalTable: "Squad_Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Squad_Checkins_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Chats_SquadId",
                table: "Chats",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_Checkins_GameId",
                table: "Squad_Checkins",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_Checkins_Squad_MemberId",
                table: "Squad_Checkins",
                column: "Squad_MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_Checkins_SquadId",
                table: "Squad_Checkins",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_Members_GameId",
                table: "Squad_Members",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_Members_PlayerId",
                table: "Squad_Members",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_Members_SquadId",
                table: "Squad_Members",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_Squads_GameId",
                table: "Squads",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Squads_SquadId",
                table: "Chats",
                column: "SquadId",
                principalTable: "Squads",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Squads_SquadId",
                table: "Chats");

            migrationBuilder.DropTable(
                name: "Squad_Checkins");

            migrationBuilder.DropTable(
                name: "Squad_Members");

            migrationBuilder.DropTable(
                name: "Squads");

            migrationBuilder.DropIndex(
                name: "IX_Chats_SquadId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "SquadId",
                table: "Chats");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Missions",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Missions",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

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

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 9, 48, 48, 839, DateTimeKind.Utc).AddTicks(1244), new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1243) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 8, 48, 48, 839, DateTimeKind.Utc).AddTicks(1253), new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1253) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 19, 11, 48, 48, 839, DateTimeKind.Utc).AddTicks(1256), new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1256) });
        }
    }
}
