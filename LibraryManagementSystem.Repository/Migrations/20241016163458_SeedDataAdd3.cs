using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdd3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { new Guid("e35e09b4-e3e3-4b1d-a70e-5ad55359c50d"), "e35e09b4-e3e3-4b1d-a70e-5ad55359c50d", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("f3a9dc58-8471-49f9-81ff-ac1594476073"), "f3a9dc58-8471-49f9-81ff-ac1594476073", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2836116b-1108-446d-b538-7d3fdc17e42d"), 0, null, "bd25c690-354e-419f-a088-cd531a15b312", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "TESLA54", "AQAAAAIAAYagAAAAEHdn5RsK2yv3kPD4Uu/b9Tz42GxiurSblUevyVTN9J2eHHRze7kP2LJTxqsv33SVDw==", null, false, null, false, "tesla54" });

            migrationBuilder.InsertData(
                table: "IdentityUserRole<string>",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e35e09b4-e3e3-4b1d-a70e-5ad55359c50d", "2836116b-1108-446d-b538-7d3fdc17e42d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e35e09b4-e3e3-4b1d-a70e-5ad55359c50d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f3a9dc58-8471-49f9-81ff-ac1594476073"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2836116b-1108-446d-b538-7d3fdc17e42d"));

            migrationBuilder.DeleteData(
                table: "IdentityUserRole<string>",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e35e09b4-e3e3-4b1d-a70e-5ad55359c50d", "2836116b-1108-446d-b538-7d3fdc17e42d" });

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
    }
}
