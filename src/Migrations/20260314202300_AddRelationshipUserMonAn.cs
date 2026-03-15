using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNauAn_TVU.Migrations
{
    public partial class AddRelationshipUserMonAn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateIndex(
                name: "IX_MonAn_UserId",
                table: "MonAn",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonAn_AspNetUsers_UserId",
                table: "MonAn",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonAn_AspNetUsers_UserId",
                table: "MonAn");

            migrationBuilder.DropIndex(
                name: "IX_MonAn_UserId",
                table: "MonAn");

            
        }
    }
}