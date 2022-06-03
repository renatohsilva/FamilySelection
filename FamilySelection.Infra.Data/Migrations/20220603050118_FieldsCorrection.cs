using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilySelection.Infra.Data.Migrations
{
    public partial class FieldsCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Families");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Families",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Families");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Families",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
