using Microsoft.EntityFrameworkCore.Migrations;

namespace EFConfig.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypePerson",
                schema: "Edari",
                table: "PersonFlunts");

            migrationBuilder.CreateTable(
                name: "PersonValueConversions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypePerson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonValueConversions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonValueConversions");

            migrationBuilder.AddColumn<string>(
                name: "TypePerson",
                schema: "Edari",
                table: "PersonFlunts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
