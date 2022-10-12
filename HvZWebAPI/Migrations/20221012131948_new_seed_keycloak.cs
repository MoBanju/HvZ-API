using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class new_seed_keycloak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 2);

            migrationBuilder.DeleteData(
                table: "PlayerKill",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { true, 1, 1 });

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

            migrationBuilder.InsertData(
                table: "Kills",
                columns: new[] { "Id", "GameId", "TimeDeath" },
                values: new object[] { 4, 3, new DateTime(2022, 10, 12, 13, 19, 48, 490, DateTimeKind.Utc).AddTicks(6053) });

            migrationBuilder.InsertData(
                table: "PlayerKill",
                columns: new[] { "IsVictim", "KillId", "PlayerId" },
                values: new object[,]
                {
                    { true, 2, 2 },
                    { false, 2, 3 },
                    { true, 1, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "GameId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                column: "GameId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "KeyCloakId", "LastName" },
                values: new object[] { "mordi", "f416c45a-2945-4047-b609-06de42279237", "007" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "KeyCloakId", "LastName" },
                values: new object[] { "Øyvind", "2e951202-167e-40fd-8fb1-91d2416d0d10", "Sande Reitan" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "KeyCloakId", "LastName" },
                values: new object[] { "Funny", "816cf1b0-c9e5-47b1-92f0-5927695b238a", "Man" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "KeyCloakId", "LastName" },
                values: new object[] { "Bertelsen", "d2cb4a5b-3bb1-4a36-b3ae-a370c26e9646", "Eivind" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlayerKill",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { true, 2, 2 });

            migrationBuilder.DeleteData(
                table: "PlayerKill",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { false, 2, 3 });

            migrationBuilder.DeleteData(
                table: "PlayerKill",
                keyColumns: new[] { "IsVictim", "KillId", "PlayerId" },
                keyValues: new object[] { true, 1, 4 });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 8, 37, 38, 846, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 8, 37, 38, 846, DateTimeKind.Utc).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 12, 8, 37, 38, 846, DateTimeKind.Utc).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 8, 37, 38, 846, DateTimeKind.Utc).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 8, 37, 38, 846, DateTimeKind.Utc).AddTicks(7292));

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeDeath",
                value: new DateTime(2022, 10, 12, 8, 37, 38, 846, DateTimeKind.Utc).AddTicks(7293));

            migrationBuilder.InsertData(
                table: "PlayerKill",
                columns: new[] { "IsVictim", "KillId", "PlayerId" },
                values: new object[] { true, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "GameId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                column: "GameId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "KeyCloakId", "LastName" },
                values: new object[] { "Ole", "KC11", "Streetman" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "KeyCloakId", "LastName" },
                values: new object[] { "Eivind", "KC12", "Johnson" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "KeyCloakId", "LastName" },
                values: new object[] { "Ibrahim", "KC13", "Banjai" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "KeyCloakId", "LastName" },
                values: new object[] { "Hakon", "KC14", "Haga" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "KeyCloakId", "LastName" },
                values: new object[,]
                {
                    { 5, "Patricia", "KC15", "Mahomes" },
                    { 6, "James", "KC16", "Jackson" },
                    { 7, "Lamar", "KC17", "Random" }
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 7);
        }
    }
}
