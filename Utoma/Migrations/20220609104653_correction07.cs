using Microsoft.EntityFrameworkCore.Migrations;

namespace Utoma.Migrations
{
    public partial class correction07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Newspapers",
                table: "newsArticles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Newspapers",
                table: "newsArticles");
        }
    }
}
