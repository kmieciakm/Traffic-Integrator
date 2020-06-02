using Microsoft.EntityFrameworkCore.Migrations;

namespace PBLWeb.Migrations
{
    public partial class Addedsupplierstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Suppliers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Suppliers");
        }
    }
}
