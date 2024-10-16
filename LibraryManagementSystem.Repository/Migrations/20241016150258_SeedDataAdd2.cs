using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2b35231-9502-4914-93cf-c949536a7774"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6c294397-7085-4bc3-a51f-395e3e7123ca"));

            migrationBuilder.DeleteData(
                table: "IdentityUserRole<string>",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a2b35231-9502-4914-93cf-c949536a7774", "6c294397-7085-4bc3-a51f-395e3e7123ca" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("854b4ad3-1c91-4f2f-9287-296d0fff8404"), "854b4ad3-1c91-4f2f-9287-296d0fff8404", "User", "USER" },
                    { new Guid("aee61274-bdba-407f-88b8-5398b16ee50e"), "aee61274-bdba-407f-88b8-5398b16ee50e", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0188a791-1bdc-4961-ba75-5b8d1a3c6c4d"), 0, null, "93b00c2a-1aad-4029-b60c-34cce12b681a", "admin@admin.com", true, false, null, null, "TESLA54", "AQAAAAIAAYagAAAAEE/Cvy2qPYXV+Pkvm/6rsw+UBSgo/oxK4PDU7gc7hCAnwVOSS+Vy4SsIuSGjWE2YGg==", null, false, null, false, "tesla54" });

            migrationBuilder.InsertData(
                table: "IdentityUserRole<string>",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "aee61274-bdba-407f-88b8-5398b16ee50e", "0188a791-1bdc-4961-ba75-5b8d1a3c6c4d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("854b4ad3-1c91-4f2f-9287-296d0fff8404"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aee61274-bdba-407f-88b8-5398b16ee50e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0188a791-1bdc-4961-ba75-5b8d1a3c6c4d"));

            migrationBuilder.DeleteData(
                table: "IdentityUserRole<string>",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aee61274-bdba-407f-88b8-5398b16ee50e", "0188a791-1bdc-4961-ba75-5b8d1a3c6c4d" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a2b35231-9502-4914-93cf-c949536a7774"), "a2b35231-9502-4914-93cf-c949536a7774", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6c294397-7085-4bc3-a51f-395e3e7123ca"), 0, null, "e489d921-af7a-44c5-b76e-a45391aa90ab", "admin@admin.com", true, false, null, null, "TESLA54", "AQAAAAIAAYagAAAAEP/WnucS6MczVcftHLiWN+q7nNwny7z8lrhSlIPrUfhN+F1/fNhDAgKWUxFnYJ2Z/Q==", null, false, null, false, "tesla54" });

            migrationBuilder.InsertData(
                table: "IdentityUserRole<string>",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a2b35231-9502-4914-93cf-c949536a7774", "6c294397-7085-4bc3-a51f-395e3e7123ca" });
        }
    }
}
