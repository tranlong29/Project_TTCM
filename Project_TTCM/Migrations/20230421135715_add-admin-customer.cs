using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_TTCM.Migrations
{
    public partial class addadmincustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Admin",
                table: "Customers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Customers");
        }
    }
}
