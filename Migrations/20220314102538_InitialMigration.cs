using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDemo.Migrations
{
    public partial class InitialMigration : Migration
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foo_Bar_BarId",
                        column: x => x.BarId,
                        principalTable: "Bar",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Bar",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Bar1" });

            migrationBuilder.InsertData(
                table: "Foo",
                columns: new[] { "Id", "BarId", "Name" },
                values: new object[] { 1, 1, "Foo1" });

            migrationBuilder.InsertData(
                table: "Foo",
                columns: new[] { "Id", "BarId", "Name" },
                values: new object[] { 2, 1, "Foo2" });

            migrationBuilder.CreateIndex(
                name: "IX_Foo_BarId",
                table: "Foo",
                column: "BarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foo");

            migrationBuilder.DropTable(
                name: "Bar");
        }
    }
}
