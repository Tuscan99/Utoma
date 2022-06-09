using Microsoft.EntityFrameworkCore.Migrations;

namespace Utoma.Migrations
{
    public partial class addotherids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_periodicals_publicationTypes_PublicationTypeId",
                table: "periodicals");

            migrationBuilder.DropForeignKey(
                name: "FK_periodicals_publishers_PublisherId",
                table: "periodicals");

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "periodicals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublicationTypeId",
                table: "periodicals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_periodicals_publicationTypes_PublicationTypeId",
                table: "periodicals",
                column: "PublicationTypeId",
                principalTable: "publicationTypes",
                principalColumn: "PublicationTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_periodicals_publishers_PublisherId",
                table: "periodicals",
                column: "PublisherId",
                principalTable: "publishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_periodicals_publicationTypes_PublicationTypeId",
                table: "periodicals");

            migrationBuilder.DropForeignKey(
                name: "FK_periodicals_publishers_PublisherId",
                table: "periodicals");

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "periodicals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationTypeId",
                table: "periodicals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_periodicals_publicationTypes_PublicationTypeId",
                table: "periodicals",
                column: "PublicationTypeId",
                principalTable: "publicationTypes",
                principalColumn: "PublicationTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_periodicals_publishers_PublisherId",
                table: "periodicals",
                column: "PublisherId",
                principalTable: "publishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
