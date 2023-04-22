using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_TTCM.Migrations
{
    public partial class updateagin : Migration
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

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISDELETE = table.Column<byte>(type: "tinyint", nullable: false),
                    ISACTIVE = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<byte>(type: "tinyint", nullable: false),
                    IsAction = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    IdCategory = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quatity = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Orderdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCustomer = table.Column<int>(type: "int", nullable: true),
                    Total_Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_Reciver = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDelete = table.Column<byte>(type: "tinyint", nullable: false),
                    IsAction = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_Configs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    IdConfig = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_Configs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_Configs_Configurations_IdConfig",
                        column: x => x.IdConfig,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_Configs_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLIMG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Images_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Return_Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Details_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Details_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdCustomer",
                table: "Orders",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Details_IdOrder",
                table: "Orders_Details",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Details_IdProduct",
                table: "Orders_Details",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_product_Configs_IdConfig",
                table: "product_Configs",
                column: "IdConfig");

            migrationBuilder.CreateIndex(
                name: "IX_product_Configs_IdProduct",
                table: "product_Configs",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Images_IdProduct",
                table: "Product_Images",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategory",
                table: "Products",
                column: "IdCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders_Details");

            migrationBuilder.DropTable(
                name: "product_Configs");

            migrationBuilder.DropTable(
                name: "Product_Images");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
