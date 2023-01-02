using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinic_backend.Migrations
{
    public partial class animals2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "animals");

            migrationBuilder.AlterColumn<string>(
                name: "Specie",
                table: "animals",
                type: "nvarchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "animals",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "animals",
                type: "nvarchar(MAX)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "animals");

            migrationBuilder.AlterColumn<string>(
                name: "Specie",
                table: "animals",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "animals",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
