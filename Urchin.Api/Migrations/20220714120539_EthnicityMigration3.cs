using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Urchin.Api.Migrations
{
    public partial class EthnicityMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EthnicityId",
                schema: "urchin",
                table: "Presidents",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Presidents_EthnicityId",
                schema: "urchin",
                table: "Presidents",
                column: "EthnicityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presidents_Ethnicities_EthnicityId",
                schema: "urchin",
                table: "Presidents",
                column: "EthnicityId",
                principalSchema: "urchin",
                principalTable: "Ethnicities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presidents_Ethnicities_EthnicityId",
                schema: "urchin",
                table: "Presidents");

            migrationBuilder.DropIndex(
                name: "IX_Presidents_EthnicityId",
                schema: "urchin",
                table: "Presidents");

            migrationBuilder.DropColumn(
                name: "EthnicityId",
                schema: "urchin",
                table: "Presidents");
        }
    }
}
