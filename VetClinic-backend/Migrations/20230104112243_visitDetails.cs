using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinic_backend.Migrations
{
    public partial class visitDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "visitDetails",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "visitDetails");
        }
    }
}
