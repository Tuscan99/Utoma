using Microsoft.EntityFrameworkCore.Migrations;

namespace Utoma.Migrations
{
    public partial class InitialCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "publicationTypes",
                columns: table => new
                {
                    PublicationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publicationTypes", x => x.PublicationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "periodicals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumPages = table.Column<int>(type: "int", nullable: false),
                    TimesOnMonth = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    PublicationTypeId = table.Column<int>(type: "int", nullable: true),
                    PublisherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodicals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_periodicals_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_periodicals_publicationTypes_PublicationTypeId",
                        column: x => x.PublicationTypeId,
                        principalTable: "publicationTypes",
                        principalColumn: "PublicationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_periodicals_publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_periodicals_CategoryId",
                table: "periodicals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_periodicals_PublicationTypeId",
                table: "periodicals",
                column: "PublicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_periodicals_PublisherId",
                table: "periodicals",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "periodicals");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "publicationTypes");

            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}
