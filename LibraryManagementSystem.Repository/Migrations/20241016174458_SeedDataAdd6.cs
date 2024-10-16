using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdd6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserRole<string>");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("59ecd787-80ee-4553-893e-38f29801aba5"), "59ecd787-80ee-4553-893e-38f29801aba5", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("8f9ad2f2-3469-4486-90fa-98cdc8de0434"), "8f9ad2f2-3469-4486-90fa-98cdc8de0434", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("baf265b0-43a5-4a18-962d-c06d91ec1dfe"), 0, null, "884f34c1-ac17-4c35-8dcf-9ca2ef8ca041", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "TESLA54", "AQAAAAIAAYagAAAAEP88CyOE/ZD/NDeQe2E/55E6SN+Si321sQyKR4wauKUMcuk52NBtlD/HDN74H9exKA==", null, false, "f4cfb74c-ae68-4012-8ff8-c9214dea155e", false, "tesla54" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("59ecd787-80ee-4553-893e-38f29801aba5"), new Guid("baf265b0-43a5-4a18-962d-c06d91ec1dfe") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8f9ad2f2-3469-4486-90fa-98cdc8de0434"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("59ecd787-80ee-4553-893e-38f29801aba5"), new Guid("baf265b0-43a5-4a18-962d-c06d91ec1dfe") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("59ecd787-80ee-4553-893e-38f29801aba5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("baf265b0-43a5-4a18-962d-c06d91ec1dfe"));

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<string>",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
                });

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
    }
}
