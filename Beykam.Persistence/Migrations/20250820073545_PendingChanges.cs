using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beykam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Jobs_JobPostId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Employers_EmployerId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Employers");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "JobPosts");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_EmployerId",
                table: "JobPosts",
                newName: "IX_JobPosts_EmployerId");

            migrationBuilder.AlterColumn<string>(
                name: "CoverLetter",
                table: "JobApplications",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Employers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationCount",
                table: "JobPosts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "JobPosts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "JobPosts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPosts",
                table: "JobPosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_JobPosts_JobPostId",
                table: "JobApplications",
                column: "JobPostId",
                principalTable: "JobPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Employers_EmployerId",
                table: "JobPosts",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_JobPosts_JobPostId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Employers_EmployerId",
                table: "JobPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPosts",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "ApplicationCount",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "JobPosts");

            migrationBuilder.RenameTable(
                name: "JobPosts",
                newName: "Jobs");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosts_EmployerId",
                table: "Jobs",
                newName: "IX_Jobs_EmployerId");

            migrationBuilder.AlterColumn<string>(
                name: "CoverLetter",
                table: "JobApplications",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedBy",
                table: "Employers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Jobs_JobPostId",
                table: "JobApplications",
                column: "JobPostId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Employers_EmployerId",
                table: "Jobs",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
