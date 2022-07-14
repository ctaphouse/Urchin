using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Urchin.Api.Migrations
{
    public partial class EthnicityMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EthnicityId",
                schema: "urchin",
                table: "Presidents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EthnicityId",
                schema: "urchin",
                table: "Presidents",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
