using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFConfig
{
    [Table("PersonAttrs", Schema = "Edari")]
    public class PersonAttr
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column("LastName", TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        public int Age { get; set; }

        [NotMapped]
        public string FullName { get; set; }
    }
}
