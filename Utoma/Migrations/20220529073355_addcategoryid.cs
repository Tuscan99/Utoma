using Microsoft.EntityFrameworkCore.Migrations;

namespace Utoma.Migrations
{
    public partial class addcategoryid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_periodicals_categories_CategoryId",
                table: "periodicals");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "periodicals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_periodicals_categories_CategoryId",
                table: "periodicals",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_periodicals_categories_CategoryId",
                table: "periodicals");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "periodicals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_periodicals_categories_CategoryId",
                table: "periodicals",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
