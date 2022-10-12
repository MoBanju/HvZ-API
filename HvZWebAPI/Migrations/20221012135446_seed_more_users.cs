using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class seed_more_users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2319));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2320));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "KeyCloakId", "LastName" },
                values: new object[,]
                {
                    { 5, "Kaffi", "fa31d802-1e3c-4909-b9e9-210978fd9688", "Elsker" },
                    { 6, "Vann", "cd501590-5292-41cd-a170-7fea0b879bb0", "Elsker" },
                    { 7, "Cola", "6cbfe3cb-9e81-438a-a56c-625624efc2a4", "Elske" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

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
        }
    }
}
