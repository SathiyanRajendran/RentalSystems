using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalSystems.Migrations
{
    public partial class migr7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email_Id",
                table: "customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email_Id",
                table: "customers");
        }
    }
}
