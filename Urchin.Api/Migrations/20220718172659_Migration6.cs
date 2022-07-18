using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Urchin.Api.Migrations
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                schema: "urchin",
                table: "Presidents",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenderId",
                schema: "urchin",
                table: "Presidents");
        }
    }
}
