using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Data.Migrations
{
    public partial class NullableImportance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Intensity",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "Importance",
                table: "Tags",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Importance",
                table: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "Intensity",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
