using Microsoft.EntityFrameworkCore.Migrations;

namespace BrassDragonArchive.Migrations
{
    public partial class AddClassAndRaceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassSkills = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    RaceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RacialBonus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RacialSkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RacialTraits = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.RaceID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
