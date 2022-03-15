using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDemo.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BarFoo",
                columns: table => new
                {
                    BarsId = table.Column<int>(type: "int", nullable: false),
                    FoosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarFoo", x => new { x.BarsId, x.FoosId });
                    table.ForeignKey(
                        name: "FK_BarFoo_Bar_BarsId",
                        column: x => x.BarsId,
                        principalTable: "Bar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarFoo_Foo_FoosId",
                        column: x => x.FoosId,
                        principalTable: "Foo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarFoo_FoosId",
                table: "BarFoo",
                column: "FoosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarFoo");

            migrationBuilder.DropTable(
                name: "Bar");

            migrationBuilder.DropTable(
                name: "Foo");
        }
    }
}
