using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    InventoryNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Wholesale = table.Column<decimal>(nullable: false),
                    Retail = table.Column<decimal>(nullable: false),
                    Worktime = table.Column<decimal>(nullable: false),
                    Labor = table.Column<decimal>(nullable: false),
                    DateAcquired = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.InventoryNumber);
                });

            migrationBuilder.CreateTable(
                name: "Fabrications",
                columns: table => new
                {
                    JobID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    WorkCompleted = table.Column<DateTime>(nullable: false),
                    FabricationType = table.Column<int>(nullable: false),
                    Retail = table.Column<decimal>(nullable: false),
                    InventoryNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrication", x => x.JobID);
                    table.ForeignKey(
                        name: "FK_Fabrications_Elements_InventoryNumber",
                        column: x => x.InventoryNumber,
                        principalTable: "Elements",
                        principalColumn: "InventoryNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fabrications_InventoryNumber",
                table: "Fabrications",
                column: "InventoryNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fabrications");

            migrationBuilder.DropTable(
                name: "Elements");
        }
    }
}
