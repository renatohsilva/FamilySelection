using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilySelection.Infra.Data.Migrations
{
    public partial class UpdateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Families_FamilyId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Pontuation",
                table: "Families");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyId",
                table: "Persons",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Persons",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Families",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Families",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Families_FamilyId",
                table: "Persons",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Families_FamilyId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Families");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyId",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Pontuation",
                table: "Families",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Families_FamilyId",
                table: "Persons",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
