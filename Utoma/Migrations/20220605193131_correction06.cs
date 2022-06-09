using Microsoft.EntityFrameworkCore.Migrations;

namespace Utoma.Migrations
{
    public partial class correction06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subscriptions_periodicals_PeriodicalId",
                table: "subscriptions");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodicalId",
                table: "subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_subscriptions_periodicals_PeriodicalId",
                table: "subscriptions",
                column: "PeriodicalId",
                principalTable: "periodicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subscriptions_periodicals_PeriodicalId",
                table: "subscriptions");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodicalId",
                table: "subscriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_subscriptions_periodicals_PeriodicalId",
                table: "subscriptions",
                column: "PeriodicalId",
                principalTable: "periodicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
