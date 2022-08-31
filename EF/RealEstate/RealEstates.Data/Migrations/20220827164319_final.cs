using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Data.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Tags_TagId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_TagId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Properties");

            migrationBuilder.CreateTable(
                name: "PropertyTag",
                columns: table => new
                {
                    PropertiesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTag", x => new { x.PropertiesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PropertyTag_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTag_TagsId",
                table: "PropertyTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyTag");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_TagId",
                table: "Properties",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Tags_TagId",
                table: "Properties",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}
