using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amino.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "d0042391-4658-4831-b855-6511fdedc9b6", "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "a42df37b-bb45-4fce-9a0d-8017ba49713f", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "f7da5a41-e089-452f-b11e-b7d3c48e9705", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAEAACcQAAAAEJDad1/vLwFtmJyJiQLTXZvvcU5w7SlyydghqZBYtXzGN+zXlbXT2Kd2oeIR8fMVbw==", null, false, "37e41a53-4299-4fd0-85f7-68fa274215a4", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 2, 7, 16, 8, 0, 696, DateTimeKind.Local).AddTicks(885), new DateTime(2023, 2, 7, 16, 8, 0, 696, DateTimeKind.Local).AddTicks(8304), "God Of War Ragnarok", "System" },
                    { 2, "System", new DateTime(2023, 2, 7, 16, 8, 0, 696, DateTimeKind.Local).AddTicks(9119), new DateTime(2023, 2, 7, 16, 8, 0, 696, DateTimeKind.Local).AddTicks(9124), "Elden Ring", "System" },
                    { 3, "System", new DateTime(2023, 2, 7, 16, 8, 0, 696, DateTimeKind.Local).AddTicks(9126), new DateTime(2023, 2, 7, 16, 8, 0, 696, DateTimeKind.Local).AddTicks(9127), "Sekiro", "System" },
                    { 4, "System", new DateTime(2023, 2, 7, 16, 8, 0, 696, DateTimeKind.Local).AddTicks(9128), new DateTime(2023, 2, 7, 16, 8, 0, 696, DateTimeKind.Local).AddTicks(9129), "Minecraft", "System" },
                    { 5, "System", new DateTime(2023, 2, 7, 16, 8, 0, 696, DateTimeKind.Local).AddTicks(9130), new DateTime(2023, 2, 7, 16, 8, 0, 696, DateTimeKind.Local).AddTicks(9131), "Gta V", "System" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 2, 7, 16, 8, 0, 697, DateTimeKind.Local).AddTicks(9155), new DateTime(2023, 2, 7, 16, 8, 0, 697, DateTimeKind.Local).AddTicks(9161), "Playstation", "System" },
                    { 2, "System", new DateTime(2023, 2, 7, 16, 8, 0, 697, DateTimeKind.Local).AddTicks(9165), new DateTime(2023, 2, 7, 16, 8, 0, 697, DateTimeKind.Local).AddTicks(9165), "Xbox", "System" },
                    { 3, "System", new DateTime(2023, 2, 7, 16, 8, 0, 697, DateTimeKind.Local).AddTicks(9167), new DateTime(2023, 2, 7, 16, 8, 0, 697, DateTimeKind.Local).AddTicks(9168), "PC", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
