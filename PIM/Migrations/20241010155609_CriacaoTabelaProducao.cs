using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaProducao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_producao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info_producao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ini_producao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Troca_substrato = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producao", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
