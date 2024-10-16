using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdd4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("0fbfff79-2da3-40c1-a277-686df8404457"), "0fbfff79-2da3-40c1-a277-686df8404457", "User", "USER" },
                    { new Guid("5fee2206-72f7-4343-a10a-bf7c84b17fbd"), "5fee2206-72f7-4343-a10a-bf7c84b17fbd", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("dfa08680-8ee1-49bb-8029-0da6b619b23b"), 0, null, "028e40ff-dc4b-4384-a13b-0ea80e27e65b", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "TESLA54", "AQAAAAIAAYagAAAAELBLsp/LY2fJrztH86o9KLneh8e9uslpDX7ghMQa0YhmQaH6uPWBbXQrFOXu9cLaCg==", null, false, "e1faeead-d9e6-4f9b-938c-5a9168618fae", false, "tesla54" });

            migrationBuilder.InsertData(
                table: "IdentityUserRole<string>",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5fee2206-72f7-4343-a10a-bf7c84b17fbd", "dfa08680-8ee1-49bb-8029-0da6b619b23b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fbfff79-2da3-40c1-a277-686df8404457"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5fee2206-72f7-4343-a10a-bf7c84b17fbd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dfa08680-8ee1-49bb-8029-0da6b619b23b"));

            migrationBuilder.DeleteData(
                table: "IdentityUserRole<string>",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5fee2206-72f7-4343-a10a-bf7c84b17fbd", "dfa08680-8ee1-49bb-8029-0da6b619b23b" });

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
    }
}
