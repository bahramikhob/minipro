using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationManyToMany.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public List<Tag> Tags { get; set; }

    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }

    }
}

