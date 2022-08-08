using Microsoft.EntityFrameworkCore.Migrations;

namespace EFConfig.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonShadows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PersonCreate = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    PersonNameCreate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TimeCreate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonShadows", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonShadows");
        }
    }
}
