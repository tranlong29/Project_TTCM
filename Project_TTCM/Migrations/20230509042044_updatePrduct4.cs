using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_TTCM.Migrations
{
    public partial class updatePrduct4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "META_DESCRIPTION",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "META_KEYWORD",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "META_TITLE",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SLUG",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Products",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "META_DESCRIPTION",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "META_KEYWORD",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "META_TITLE",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SLUG",
                table: "Products",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
