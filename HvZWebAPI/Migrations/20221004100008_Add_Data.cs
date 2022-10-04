using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class Add_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Games",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { 1, "Jungle", 0 },
                    { 2, "Island", 1 },
                    { 3, "Ocean", 1 },
                    { 4, "Space", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Ole", "Streetman" },
                    { 2, "Eivind", "Johnson" },
                    { 3, "Ibrahim", "Banjai" },
                    { 4, "Hakon", "Haga" },
                    { 5, "Patricia", "Mahomes" },
                    { 6, "James", "Jackson" },
                    { 7, "Lamar", "Random" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BiteCode", "GameId", "IsHuman", "IsPatientZero", "UserId" },
                values: new object[,]
                {
                    { 1, "Street", 2, true, false, 1 },
                    { 2, "BooHoo", 2, false, true, 3 },
                    { 3, "Hello", 2, false, false, 4 },
                    { 4, "Hello", 2, true, false, 7 }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "ChatTime", "GameId", "IsHumanGlobal", "IsZombieGlobal", "Message", "PlayerId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 4, 12, 0, 8, 394, DateTimeKind.Local).AddTicks(6495), 2, false, true, "Got him!", 2 },
                    { 2, new DateTime(2022, 10, 4, 12, 0, 8, 394, DateTimeKind.Local).AddTicks(6505), 2, true, false, "Run away!", 1 },
                    { 3, new DateTime(2022, 10, 4, 12, 0, 8, 394, DateTimeKind.Local).AddTicks(6512), 2, false, false, "Like... Hello", 3 }
                });

            migrationBuilder.InsertData(
                table: "Kills",
                columns: new[] { "Id", "GameId", "KillerId", "TimeDeath", "VictimId" },
                values: new object[,]
                {
                    { 1, 2, 2, new DateTime(2022, 10, 4, 12, 0, 8, 394, DateTimeKind.Local).AddTicks(6375), 1 },
                    { 2, 2, 4, new DateTime(2022, 10, 4, 12, 0, 8, 394, DateTimeKind.Local).AddTicks(6437), 3 },
                    { 3, 2, 2, new DateTime(2022, 10, 4, 12, 0, 8, 394, DateTimeKind.Local).AddTicks(6442), 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
