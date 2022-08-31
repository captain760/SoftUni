using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Data.Migrations
{
    public partial class NullableTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Tags_TagId",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Tags_TagId",
                table: "Properties",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Tags_TagId",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Tags_TagId",
                table: "Properties",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
