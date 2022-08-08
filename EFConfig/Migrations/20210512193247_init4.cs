using Microsoft.EntityFrameworkCore.Migrations;

namespace EFConfig.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW [dbo].[vmPerson]
AS
SELECT        FirstName, LastName
FROM            Edari.PersonFlunts
GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
