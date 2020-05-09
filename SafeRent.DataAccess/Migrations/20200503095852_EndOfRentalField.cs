using Microsoft.EntityFrameworkCore.Migrations;

namespace SafeRent.DataAccess.Migrations
{
    public partial class EndOfRentalField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndOfRental",
                table: "ApplicationUserApartment",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndOfRental",
                table: "ApplicationUserApartment");
        }
    }
}
