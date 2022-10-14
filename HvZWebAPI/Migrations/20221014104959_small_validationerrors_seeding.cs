using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class small_validationerrors_seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Chats",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ChatTime", "GameId" },
                values: new object[] { new DateTime(2022, 10, 14, 10, 49, 59, 298, DateTimeKind.Utc).AddTicks(537), 3 });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ChatTime", "IsHumanGlobal" },
                values: new object[] { new DateTime(2022, 10, 14, 10, 49, 59, 298, DateTimeKind.Utc).AddTicks(541), false });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ChatTime", "GameId", "IsHumanGlobal", "PlayerId" },
                values: new object[] { new DateTime(2022, 10, 14, 10, 49, 59, 298, DateTimeKind.Utc).AddTicks(542), 1, true, 7 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 14, 10, 49, 59, 298, DateTimeKind.Utc).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GameId", "TimeDeath" },
                values: new object[] { 3, new DateTime(2022, 10, 14, 10, 49, 59, 298, DateTimeKind.Utc).AddTicks(523) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsHuman",
                value: false);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsPatientZero",
                value: false);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsPatientZero",
                value: true);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsHuman", "IsPatientZero" },
                values: new object[] { false, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ChatTime", "GameId" },
                values: new object[] { new DateTime(2022, 10, 13, 7, 25, 44, 467, DateTimeKind.Utc).AddTicks(9759), 2 });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ChatTime", "IsHumanGlobal" },
                values: new object[] { new DateTime(2022, 10, 13, 7, 25, 44, 467, DateTimeKind.Utc).AddTicks(9766), true });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ChatTime", "GameId", "IsHumanGlobal", "PlayerId" },
                values: new object[] { new DateTime(2022, 10, 13, 7, 25, 44, 467, DateTimeKind.Utc).AddTicks(9769), 3, false, 3 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 13, 7, 25, 44, 467, DateTimeKind.Utc).AddTicks(9703));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GameId", "TimeDeath" },
                values: new object[] { 2, new DateTime(2022, 10, 13, 7, 25, 44, 467, DateTimeKind.Utc).AddTicks(9715) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsHuman",
                value: true);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsPatientZero",
                value: true);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsPatientZero",
                value: false);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsHuman", "IsPatientZero" },
                values: new object[] { true, false });
        }
    }
}
