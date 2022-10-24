using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HvZWebAPI.Migrations
{
    public partial class our_area_seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChatTime",
                value: new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChatTime",
                value: new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(5417));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChatTime",
                value: new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(5420));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 58.905665242375598, 5.7555253369979997, 58.857403644349702, 5.6596354024622704 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 58.890768111882799, 5.7620554759090101, 58.850655853113501, 5.6369517620345002 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 58.8957799309783, 5.7656575990670804, 58.8844258924142, 5.6463966410603001 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 58.887403644349703, 5.7000000000000002 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 58.859999999999999, 5.7000000000000002 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 58.869999999999997, 5.6500000000000004 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 58.890000000000001, 5.6799999999999997 });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End_time", "Latitude", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 24, 11, 43, 0, 538, DateTimeKind.Utc).AddTicks(5553), 58.893000000000001, 5.7599999999999998, new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(5552) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 43, 0, 538, DateTimeKind.Utc).AddTicks(5545), new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(5544) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 24, 13, 43, 0, 538, DateTimeKind.Utc).AddTicks(5549), new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(5548) });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "End_time", "Latitude", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 24, 13, 43, 0, 538, DateTimeKind.Utc).AddTicks(5528), 58.884999999999998, 5.7199999999999998, new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(5527) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BiteCode", "UserId" },
                values: new object[] { "udo9zhwi9q", 5 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "BiteCode",
                value: "86bhuu95llh");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                column: "BiteCode",
                value: "hphhgffkt27");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                column: "BiteCode",
                value: "gnr5uvef03");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BiteCode", "UserId" },
                values: new object[] { "8xl2v6cho4w", 5 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6,
                column: "BiteCode",
                value: "ao56yqf3nel");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7,
                column: "BiteCode",
                value: "7cbq3kjnz9f");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BiteCode", "UserId" },
                values: new object[] { "pzuaz7xxts", 5 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9,
                column: "BiteCode",
                value: "pt4nv8yilk");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10,
                column: "BiteCode",
                value: "0ox01mfifxu");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 11,
                column: "BiteCode",
                value: "y4agjazrxt");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 12,
                column: "BiteCode",
                value: "22k36equedx");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 13,
                column: "BiteCode",
                value: "7ijo6pppt9d");

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BiteCode", "GameId", "IsHuman", "IsPatientZero", "UserId" },
                values: new object[] { 14, "n7p3cb0xoh", 2, false, false, 4 });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End_time", "Latitude", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 13, 0, 538, DateTimeKind.Utc).AddTicks(6659), 58.880000000000003, 5.7300000000000004, new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(6657) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End_time", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 3, 0, 538, DateTimeKind.Utc).AddTicks(6670), new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(6669) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End_time", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 38, 0, 538, DateTimeKind.Utc).AddTicks(6679), 5.71, new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(6678) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "End_time", "Latitude", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 38, 0, 538, DateTimeKind.Utc).AddTicks(6683), 58.859999999999999, 5.7300000000000004, new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(6682) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "End_time", "Latitude", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 24, 9, 46, 0, 538, DateTimeKind.Utc).AddTicks(6686), 58.869999999999997, 5.7599999999999998, new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(6686) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "End_time", "Latitude", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 38, 0, 538, DateTimeKind.Utc).AddTicks(6692), 58.890000000000001, 5.6500000000000004, new DateTime(2022, 10, 24, 9, 43, 0, 538, DateTimeKind.Utc).AddTicks(6692) });

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 11,
                column: "PlayerId",
                value: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 14);

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
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 60.395527999999999, 5.320989, 60.395122999999998, 5.3146870000000002 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 58.895001999999998, 5.6449809999999996, 58.870288000000002, 5.6021359999999998 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Ne_lat", "Ne_lng", "Sw_lat", "Sw_lng" },
                values: new object[] { 58.964326999999997, 5.8464679999999998, 58.940604999999998, 5.8035119999999996 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 58.983899999999998, 5.6150000000000002 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 58.885641999999997, 5.6335850000000001 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 58.893352999999998, 5.6372780000000002 });

            migrationBuilder.UpdateData(
                table: "Kills",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 58.950000000000003, 5.8099999999999996 });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End_time", "Latitude", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 14, 41, 45, 384, DateTimeKind.Utc).AddTicks(3924), 58.880000000000003, 5.6100000000000003, new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(3923) });

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

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "End_time", "Latitude", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 16, 41, 45, 384, DateTimeKind.Utc).AddTicks(3938), 60.395200000000003, 5.3200000000000003, new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(3938) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BiteCode", "UserId" },
                values: new object[] { "Street", 1 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "BiteCode",
                value: "BooHoo");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                column: "BiteCode",
                value: "Hello");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                column: "BiteCode",
                value: "Helloma");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BiteCode", "UserId" },
                values: new object[] { "Five", 1 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6,
                column: "BiteCode",
                value: "Six");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7,
                column: "BiteCode",
                value: "Seven");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BiteCode", "UserId" },
                values: new object[] { "Eight", 1 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9,
                column: "BiteCode",
                value: "Nine");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10,
                column: "BiteCode",
                value: "DontGuessMe");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 11,
                column: "BiteCode",
                value: "NoGuess");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 12,
                column: "BiteCode",
                value: "DontAtMeBro");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 13,
                column: "BiteCode",
                value: "HellomaSma");

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End_time", "Latitude", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 11, 45, 384, DateTimeKind.Utc).AddTicks(4069), 60.395299999999999, 5.3150000000000004, new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(4069) });

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
                columns: new[] { "End_time", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 36, 45, 384, DateTimeKind.Utc).AddTicks(4075), 5.6100000000000003, new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(4075) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "End_time", "Latitude", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 36, 45, 384, DateTimeKind.Utc).AddTicks(4077), 58.890000000000001, 5.6299999999999999, new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(4076) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "End_time", "Latitude", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 12, 44, 45, 384, DateTimeKind.Utc).AddTicks(4078), 58.890000000000001, 5.6299999999999999, new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "Squad_Checkins",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "End_time", "Latitude", "Longitude", "Start_time" },
                values: new object[] { new DateTime(2022, 10, 20, 13, 36, 45, 384, DateTimeKind.Utc).AddTicks(4080), 58.950000000000003, 5.8200000000000003, new DateTime(2022, 10, 20, 12, 41, 45, 384, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "Squad_Members",
                keyColumn: "Id",
                keyValue: 11,
                column: "PlayerId",
                value: 4);
        }
    }
}
