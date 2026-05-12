using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serveur.Migrations
{
    /// <inheritdoc />
    public partial class v10_CréationBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dépense",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dépense", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Investissement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investissement", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Revenu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenu", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dépense");

            migrationBuilder.DropTable(
                name: "Investissement");

            migrationBuilder.DropTable(
                name: "Revenu");
        }
    }
}
