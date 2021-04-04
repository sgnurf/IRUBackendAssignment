using Microsoft.EntityFrameworkCore.Migrations;

namespace IReckonUAssignment.EntityFrameworkDAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    ColorCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", nullable: true),
                    Q1 = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Key = table.Column<string>(type: "varchar(200)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DiscountPrice = table.Column<int>(type: "int", nullable: true),
                    DeliveredIn = table.Column<string>(type: "varchar(200)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "varchar(50)", nullable: true),
                    ArticleCode = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Products_Articles_ArticleCode",
                        column: x => x.ArticleCode,
                        principalTable: "Articles",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ArticleCode",
                table: "Products",
                column: "ArticleCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
