using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinic_backend.Migrations
{
    public partial class visitDetailsBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Bill",
                table: "visitDetails",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bill",
                table: "visitDetails");
        }
    }
}
