using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAMVC.Migrations
{
    public partial class addBeer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Brewery = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    AlcPercent = table.Column<float>(nullable: false),
                    PerceivedBitterness = table.Column<float>(nullable: true),
                    PerceivedSweetness = table.Column<float>(nullable: true),
                    PerceivedFruitiness = table.Column<float>(nullable: true),
                    ActualIBU = table.Column<float>(nullable: false),
                    DrinkingTime = table.Column<DateTime>(nullable: false),
                    SubmittedByUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beers");
        }
    }
}
