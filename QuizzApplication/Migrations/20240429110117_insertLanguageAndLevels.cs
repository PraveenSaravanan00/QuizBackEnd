using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizzApplication.Migrations
{
    /// <inheritdoc />
    public partial class insertLanguageAndLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Languages",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Levels",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Languages",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Levels",
                table: "Questions");
        }
    }
}
