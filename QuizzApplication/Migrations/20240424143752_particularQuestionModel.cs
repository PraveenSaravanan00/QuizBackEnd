using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizzApplication.Migrations
{
    /// <inheritdoc />
    public partial class particularQuestionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "particularQuestion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "particularQuestion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    optionA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    optionB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    optionC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    optionD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    questions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_particularQuestion", x => x.id);
                });
        }
    }
}
