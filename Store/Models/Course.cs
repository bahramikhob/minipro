using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public Discount Discount { get; set; }
        public List<Tag> Tags { get; set; }
        public List<CourseTeacher> CourseTeachers { get; set; }
        public List<Comment> Comments { get; set; }
        public bool IsDeleted { get; set; }

        public string FullName => $"{Title}, {Price}";

        internal static object StaticMethod()
        {
            return " static method ";
        }

        internal string LocalMethod()
        {
            return Title + " local method";
        }
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }

    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NewPrice { get; set; }
        public int CourseId { get; set; }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Course> Courses { get; set; }
    }
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName}, {LastName}";
        public List<CourseTeacher> CourseTeachers { get; set; }
    }
    public class CourseTeacher
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        public int SortOrder { get; set; }

    }


}
