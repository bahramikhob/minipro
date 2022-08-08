namespace EFConfig
{
    public class PersonFluentPk
    {

        public int MyPrimaryKey01 { get; set; }
        public int MyPrimaryKey02 { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    //Note
    //builder.HasKey(p =>new{MyPrimaryKey01,MyPrimaryKey02});
}
