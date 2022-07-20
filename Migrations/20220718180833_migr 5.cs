using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalSystems.Migrations
{
    public partial class migr5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Charge",
                table: "rentalPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GST",
                table: "rentalPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "rentalPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Charge",
                table: "rentalPayments");

            migrationBuilder.DropColumn(
                name: "GST",
                table: "rentalPayments");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "rentalPayments");
        }
    }
}
