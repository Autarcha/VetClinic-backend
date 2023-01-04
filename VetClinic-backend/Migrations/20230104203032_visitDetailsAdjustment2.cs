using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinic_backend.Migrations
{
    public partial class visitDetailsAdjustment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_visits_VisitDetailsId",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "visitDetails");

            migrationBuilder.CreateIndex(
                name: "IX_visits_VisitDetailsId",
                table: "visits",
                column: "VisitDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_visits_VisitDetailsId",
                table: "visits");

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "visitDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_visits_VisitDetailsId",
                table: "visits",
                column: "VisitDetailsId",
                unique: true,
                filter: "[VisitDetailsId] IS NOT NULL");
        }
    }
}
