using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Data.Migartions
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdcutBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdcutBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prodcuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodcuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prodcuts_ProdcutBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "ProdcutBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prodcuts_productTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "productTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prodcuts_BrandId",
                table: "Prodcuts",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodcuts_TypeId",
                table: "Prodcuts",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prodcuts");

            migrationBuilder.DropTable(
                name: "ProdcutBrands");

            migrationBuilder.DropTable(
                name: "productTypes");
        }
    }
}
