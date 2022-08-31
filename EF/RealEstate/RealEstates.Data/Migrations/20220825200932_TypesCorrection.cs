using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Data.Migrations
{
    public partial class TypesCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Properties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
