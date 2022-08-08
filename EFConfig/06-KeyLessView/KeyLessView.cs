namespace EFConfig
{
    public class KeyLessView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        /*
         add command under to method up migration:
        migrationBuilder.Sql(@"CREATE VIEW [dbo].[vmPerson]
                                    AS
                                 SELECT FirstName, LastName FROM  Edari.PersonFlunts");
        */
    }
}
