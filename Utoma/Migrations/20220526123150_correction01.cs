using Microsoft.EntityFrameworkCore.Migrations;

namespace Utoma.Migrations
{
    public partial class correction01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimesOnMonth",
                table: "periodicals",
                newName: "TimesInMonth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimesInMonth",
                table: "periodicals",
                newName: "TimesOnMonth");
        }
    }
}
