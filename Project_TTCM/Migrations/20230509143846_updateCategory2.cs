using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_TTCM.Migrations
{
    public partial class updateCategory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ICON",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "META_DESCRIPTION",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "META_KEYWORD",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "META_TITLE",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SLUG",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ICON",
                table: "Categories",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "META_DESCRIPTION",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "META_KEYWORD",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "META_TITLE",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SLUG",
                table: "Categories",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
