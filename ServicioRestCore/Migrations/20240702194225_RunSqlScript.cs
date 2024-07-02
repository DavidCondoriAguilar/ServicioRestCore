using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioRestCore.Migrations
{
    /// <inheritdoc />
    public partial class RunSqlScript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    codcat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomcat = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    escat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.codcat);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    codpro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nompro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    despro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prepro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    canpro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estpro = table.Column<bool>(type: "bit", nullable: false),
                    codcat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.codpro);
                    table.ForeignKey(
                        name: "FK_producto_categoria_codcat",
                        column: x => x.codcat,
                        principalTable: "categoria",
                        principalColumn: "codcat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_producto_codcat",
                table: "producto",
                column: "codcat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
