using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TBApp.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "50c949f8-7123-4885-9d97-e04291fc7b95", 0, "d1107fd5-b6a4-40ec-834e-d9e5e4c11ecd", "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEFUcnynP2BMzK8smFDdork0cEQR2bu3NfTVPzRKTmWgLBDiA+fQIjV4G7Lt3EcmCnQ==", null, false, "a808c6b1-66d4-453f-8437-e489e900bb36", false, "guest" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 18, 11, 17, 56, 243, DateTimeKind.Local).AddTicks(9591), "Learn using ASP.NET Core Identity", "50c949f8-7123-4885-9d97-e04291fc7b95", "Prepare for ASP.NET Fundamentals exam" },
                    { 2, 3, new DateTime(2022, 5, 18, 11, 17, 56, 243, DateTimeKind.Local).AddTicks(9631), "Learn using EF Core and MS SQL SMS", "50c949f8-7123-4885-9d97-e04291fc7b95", "Improve EF Core skills" },
                    { 3, 2, new DateTime(2021, 12, 18, 11, 17, 56, 243, DateTimeKind.Local).AddTicks(9635), "Learn using ASP.NET Core Identity", "50c949f8-7123-4885-9d97-e04291fc7b95", "Improve ASP.NET skills" },
                    { 4, 3, new DateTime(2021, 10, 18, 11, 17, 56, 243, DateTimeKind.Local).AddTicks(9637), "Prepare for solving old Mid and Final exams", "50c949f8-7123-4885-9d97-e04291fc7b95", "Prepare for C# Fundamentals exam" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "50c949f8-7123-4885-9d97-e04291fc7b95");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
