using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Urchin.Api.Migrations
{
    public partial class Migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Presidents_GenderId",
                schema: "urchin",
                table: "Presidents",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presidents_Genders_GenderId",
                schema: "urchin",
                table: "Presidents",
                column: "GenderId",
                principalSchema: "urchin",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presidents_Genders_GenderId",
                schema: "urchin",
                table: "Presidents");

            migrationBuilder.DropIndex(
                name: "IX_Presidents_GenderId",
                schema: "urchin",
                table: "Presidents");
        }
    }
}
