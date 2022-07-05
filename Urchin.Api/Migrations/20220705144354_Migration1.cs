using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Urchin.Api.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "urchin");

            migrationBuilder.CreateTable(
                name: "Parties",
                schema: "urchin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                schema: "urchin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Presidents",
                schema: "urchin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presidents_Parties_PartyId",
                        column: x => x.PartyId,
                        principalSchema: "urchin",
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PresidentVoter",
                schema: "urchin",
                columns: table => new
                {
                    PresidentsId = table.Column<int>(type: "int", nullable: false),
                    VotersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresidentVoter", x => new { x.PresidentsId, x.VotersId });
                    table.ForeignKey(
                        name: "FK_PresidentVoter_Presidents_PresidentsId",
                        column: x => x.PresidentsId,
                        principalSchema: "urchin",
                        principalTable: "Presidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PresidentVoter_Voters_VotersId",
                        column: x => x.VotersId,
                        principalSchema: "urchin",
                        principalTable: "Voters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presidents_PartyId",
                schema: "urchin",
                table: "Presidents",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_PresidentVoter_VotersId",
                schema: "urchin",
                table: "PresidentVoter",
                column: "VotersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresidentVoter",
                schema: "urchin");

            migrationBuilder.DropTable(
                name: "Presidents",
                schema: "urchin");

            migrationBuilder.DropTable(
                name: "Voters",
                schema: "urchin");

            migrationBuilder.DropTable(
                name: "Parties",
                schema: "urchin");
        }
    }
}
