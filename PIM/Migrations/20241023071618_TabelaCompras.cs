using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM.Migrations
{
    /// <inheritdoc />
    public partial class TabelaCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_fornecedor = table.Column<string>(type: "VARCHAR(80)", nullable: false), 
                    Produto_comprado = table.Column<string>(type: "VARCHAR(80)", nullable: false), 
                    Qtd_comprada = table.Column<string>(type: "VARCHAR(15)", nullable: false), 
                    Valor_total = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");
        }
    }
}
