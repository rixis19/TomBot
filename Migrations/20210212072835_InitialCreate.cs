using Microsoft.EntityFrameworkCore.Migrations;

namespace TomBot.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EightBallAnswer",
                columns: table => new
                {
                    AnswerId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnswerText = table.Column<string>(nullable: true),
                    AnswerColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EightBallAnswer", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "RememberThis",
                columns: table => new
                {
                    AnswerId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnswerText = table.Column<string>(nullable: true),
                    AnswerAuthor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RememberThis", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "TomQuotes",
                columns: table => new
                {
                    AnswerId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnswerText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TomQuotes", x => x.AnswerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EightBallAnswer");

            migrationBuilder.DropTable(
                name: "RememberThis");

            migrationBuilder.DropTable(
                name: "TomQuotes");
        }
    }
}
