using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beykam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CandidateEntityChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CandidateExperiences",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "CandidateEducations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CandidateExperiences");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "CandidateEducations");
        }
    }
}
