using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinic_backend.Migrations
{
    public partial class visits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "visitDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitPurpose = table.Column<string>(type: "varchar(60)", nullable: false),
                    Description = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    AppliedDrugs = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Prescription = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Recommendations = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    VisitDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    VisitStatus = table.Column<int>(type: "int", nullable: false),
                    VisitDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_visits_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_visits_users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_visits_users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_visits_visitDetails_VisitDetailsId",
                        column: x => x.VisitDetailsId,
                        principalTable: "visitDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_visits_AnimalId",
                table: "visits",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_visits_CustomerId",
                table: "visits",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_visits_EmployeeId",
                table: "visits",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_visits_VisitDetailsId",
                table: "visits",
                column: "VisitDetailsId",
                unique: true,
                filter: "[VisitDetailsId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "visits");

            migrationBuilder.DropTable(
                name: "visitDetails");
        }
    }
}
