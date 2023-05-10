using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_TTCM.Migrations
{
    public partial class updateCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATED_BY",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ISACTIVE",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ISDELETE",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "ISACTIVE",
                table: "Categories",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ISDELETE",
                table: "Categories",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
