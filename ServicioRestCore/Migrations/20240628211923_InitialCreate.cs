using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioRestCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    codcat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomcat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    escat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.codcat);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    codpro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nompro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    despro = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    prepro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    canpro = table.Column<double>(type: "float", nullable: false),
                    estpro = table.Column<bool>(type: "bit", nullable: false),
                    codcat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.codpro);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_codcat",
                        column: x => x.codcat,
                        principalTable: "Categorias",
                        principalColumn: "codcat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_codcat",
                table: "Productos",
                column: "codcat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
