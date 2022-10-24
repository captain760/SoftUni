using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodMasters2.Core.Migrations
{
    public partial class CorrectingRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterPieces_AspNetUsers_MasterId",
                table: "MasterPieces");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterPieces_Categories_CategoryId",
                table: "MasterPieces");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterPieces_Woods_WoodId",
                table: "MasterPieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Woods_Stains_StainId",
                table: "Woods");

            migrationBuilder.DropForeignKey(
                name: "FK_Woods_Suppliers_SupplierId",
                table: "Woods");

            migrationBuilder.DropIndex(
                name: "IX_Woods_StainId",
                table: "Woods");

            migrationBuilder.DropIndex(
                name: "IX_Woods_SupplierId",
                table: "Woods");

            migrationBuilder.DropIndex(
                name: "IX_MasterPieces_CategoryId",
                table: "MasterPieces");

            migrationBuilder.DropIndex(
                name: "IX_MasterPieces_MasterId",
                table: "MasterPieces");

            migrationBuilder.DropIndex(
                name: "IX_MasterPieces_WoodId",
                table: "MasterPieces");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StainId",
                table: "Woods");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Woods");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MasterPieces");

            migrationBuilder.DropColumn(
                name: "MasterId",
                table: "MasterPieces");

            migrationBuilder.DropColumn(
                name: "WoodId",
                table: "MasterPieces");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StainId",
                table: "Woods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Woods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MasterPieces",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MasterId",
                table: "MasterPieces",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WoodId",
                table: "MasterPieces",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Woods_StainId",
                table: "Woods",
                column: "StainId");

            migrationBuilder.CreateIndex(
                name: "IX_Woods_SupplierId",
                table: "Woods",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPieces_CategoryId",
                table: "MasterPieces",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPieces_MasterId",
                table: "MasterPieces",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPieces_WoodId",
                table: "MasterPieces",
                column: "WoodId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterPieces_AspNetUsers_MasterId",
                table: "MasterPieces",
                column: "MasterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterPieces_Categories_CategoryId",
                table: "MasterPieces",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterPieces_Woods_WoodId",
                table: "MasterPieces",
                column: "WoodId",
                principalTable: "Woods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Woods_Stains_StainId",
                table: "Woods",
                column: "StainId",
                principalTable: "Stains",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Woods_Suppliers_SupplierId",
                table: "Woods",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}
