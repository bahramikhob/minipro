using Microsoft.EntityFrameworkCore.Migrations;

namespace EFConfig.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypePerson",
                schema: "Edari",
                table: "PersonFlunts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypePerson",
                schema: "Edari",
                table: "PersonFlunts");
        }
    }
}
