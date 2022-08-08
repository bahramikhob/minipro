using Microsoft.EntityFrameworkCore.Migrations;

namespace EFConfig.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "KeyLessEntity",
                newName: "KeyLessEntitys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "KeyLessEntitys",
                newName: "KeyLessEntity");
        }
    }
}
