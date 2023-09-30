using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class Shoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartShoes_Shoes_TicketsId",
                table: "CartShoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Shoes_ShoesId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "ShoesId",
                table: "Photos",
                newName: "ShoesID");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_ShoesId",
                table: "Photos",
                newName: "IX_Photos_ShoesID");

            migrationBuilder.RenameColumn(
                name: "TicketsId",
                table: "CartShoes",
                newName: "ShoesId");

            migrationBuilder.RenameIndex(
                name: "IX_CartShoes_TicketsId",
                table: "CartShoes",
                newName: "IX_CartShoes_ShoesId");

            migrationBuilder.AlterColumn<int>(
                name: "ShoesID",
                table: "Photos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartShoes_Shoes_ShoesId",
                table: "CartShoes",
                column: "ShoesId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Shoes_ShoesID",
                table: "Photos",
                column: "ShoesID",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartShoes_Shoes_ShoesId",
                table: "CartShoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Shoes_ShoesID",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "ShoesID",
                table: "Photos",
                newName: "ShoesId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_ShoesID",
                table: "Photos",
                newName: "IX_Photos_ShoesId");

            migrationBuilder.RenameColumn(
                name: "ShoesId",
                table: "CartShoes",
                newName: "TicketsId");

            migrationBuilder.RenameIndex(
                name: "IX_CartShoes_ShoesId",
                table: "CartShoes",
                newName: "IX_CartShoes_TicketsId");

            migrationBuilder.AlterColumn<int>(
                name: "ShoesId",
                table: "Photos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Photos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CartShoes_Shoes_TicketsId",
                table: "CartShoes",
                column: "TicketsId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Shoes_ShoesId",
                table: "Photos",
                column: "ShoesId",
                principalTable: "Shoes",
                principalColumn: "Id");
        }
    }
}
