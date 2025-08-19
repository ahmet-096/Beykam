using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beykam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdminRoleRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d9dc372e-2c88-494a-a066-cc9d6f98f0ae"), null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { new Guid("460aa30c-41d3-45ff-b876-2ea8c223de4b"), 0, "3edb4da9-34d2-4a51-8918-23cdd13b7484", "admin@beykam.com", true, "System Administrator", true, false, null, "ADMIN@BEYKAM.COM", "ADMIN", "AQAAAAIAAYagAAAAEKhY4MUurUZ2tS+YJunX+RxeuOVGastD4u6PgU+fXqrCGeAC6UCBGoYTO4UCipjsJg==", null, false, "2bd671e2-49da-4f69-848e-5409ddfae575", false, "admin", 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("d9dc372e-2c88-494a-a066-cc9d6f98f0ae"), new Guid("460aa30c-41d3-45ff-b876-2ea8c223de4b") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d9dc372e-2c88-494a-a066-cc9d6f98f0ae"), new Guid("460aa30c-41d3-45ff-b876-2ea8c223de4b") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d9dc372e-2c88-494a-a066-cc9d6f98f0ae"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("460aa30c-41d3-45ff-b876-2ea8c223de4b"));

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
    }
}
