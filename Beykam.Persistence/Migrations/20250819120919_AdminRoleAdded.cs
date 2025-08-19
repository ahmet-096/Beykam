using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beykam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdminRoleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("4832e535-4b77-419f-8701-c6a300896b91"), null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { new Guid("cd8f3605-840c-44dc-84a8-05f72f30b027"), 0, "e9cc0e03-9f74-46a4-9b18-b98a71c02949", "admin@beykam.com", true, "System Administrator", true, false, null, "ADMIN@BEYKAM.COM", "ADMIN", "AQAAAAIAAYagAAAAELlXlSxCYBsdGul9L4mRfyH+VFspVm/YwFo0BiNrd6jiDbMU3eS+pdlqK2GQc/AyXg==", null, false, "32d678c3-b1a2-48b6-b5cc-d007ee0f919c", false, "admin", 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("4832e535-4b77-419f-8701-c6a300896b91"), new Guid("cd8f3605-840c-44dc-84a8-05f72f30b027") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4832e535-4b77-419f-8701-c6a300896b91"), new Guid("cd8f3605-840c-44dc-84a8-05f72f30b027") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4832e535-4b77-419f-8701-c6a300896b91"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cd8f3605-840c-44dc-84a8-05f72f30b027"));
        }
    }
}
