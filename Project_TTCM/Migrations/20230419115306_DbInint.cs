using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_TTCM.Migrations
{
    public partial class DbInint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ICON = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SLUG = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    META_TITLE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    META_DESCRIPTION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    META_KEYWORD = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    ISDELETE = table.Column<byte>(type: "tinyint", nullable: false),
                    ISACTIVE = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
