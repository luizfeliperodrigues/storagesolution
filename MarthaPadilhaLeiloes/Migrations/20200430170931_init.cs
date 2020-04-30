using Microsoft.EntityFrameworkCore.Migrations;

namespace MarthaPadilhaLeiloes.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comitentes",
                columns: table => new
                {
                    ComitenteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComitenteName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comitentes", x => x.ComitenteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comitentes");
        }
    }
}
