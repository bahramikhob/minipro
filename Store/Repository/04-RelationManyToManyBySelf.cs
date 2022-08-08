using Microsoft.EntityFrameworkCore;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
  public  class RelationManyToManyBySelf
    {
        public static void AddEmployees()
        {
            var ctx = ContextFactory.GetSqlContext();
            var emp = new Employee
            {
                FirstName = "FNameRoot",
                LastName = "LNameRoot",
                Children = new List<Employee>
                {
                    new Employee
                    {
                        FirstName = "Level0101",
                        LastName = "Level0101",
                        Children = new List<Employee>
                        {
                            new Employee
                            {
                                FirstName = "Level0201",
                                LastName = "Level0201"
                            },
                            new Employee
                            {
                                FirstName = "Level0202",
                                LastName = "Level0202"
                            }
                        }
                    },
                    new Employee
                    {
                        FirstName = "Level0102",
                        LastName = "Level0102"
                    }
                }
            };
            ctx.Employees.Add(emp);
            ctx.SaveChanges();
        }
        public static void ReadEmployees()
        {
            //لود کردن کلیه فرزندان به صورت درختی
            var ctx = ContextFactory.GetSqlContext();
            var empList = ctx.Employees.Include(c => c.Children).ToList();
        }

        public static void AddParent()
        {
            var ctx = ContextFactory.GetSqlContext();
            var parent = new Parent
            {
                Name = "P01",
                Child01s = new List<Child01>(),
                Child02s = new List<Child02>(),
                Child03s = new List<Child03>()
            };
            for (int i = 0; i < 10; i++)
            {
                parent.Child01s.Add(new Child01
                {
                    Name = $"child{i}"
                });
                parent.Child02s.Add(new Child02
                {
                    Name = $"child{i}"
                });
                parent.Child03s.Add(new Child03
                {
                    Name = $"child{i}"
                });
            }
            ctx.Parent.Add(parent);
            ctx.SaveChanges();
        }
        public static void GetParentIncludeChild()
        {
            /*
اگر در یک رابطه یک به چند هنگام لود کردن
 child ها،
  تعداد
child 
کمتر از 100 باشد از طریق
 include 
ولی اگر بیشتر بود از طریق 
AsSplitQuery
 انجام شود توی سرعت خیلی تاثیر داره.             * */
            var ctx = ContextFactory.GetSqlContext();
            var parentQuery = ctx.Parent
                .Include(c => c.Child01s)
                .Include(c => c.Child02s)
                .Include(c => c.Child03s)
                .AsQueryable();

            var queryText = parentQuery.ToQueryString();
            var result = parentQuery.ToList();
        }

        public static void AddChildToParent()
        {
            var ctx = ContextFactory.GetSqlContext();
            var parent = ctx.Parent
                .Include(c => c.Child01s)
                .Include(c => c.Child02s)
                .Include(c => c.Child03s)
                .Where(c => c.Id == 1)
                .SingleOrDefault();

            for (int i = 300; i < 600; i++)
            {
                parent.Child01s.Add(new Child01
                {
                    Name = $"child{i}"
                });
                parent.Child02s.Add(new Child02
                {
                    Name = $"child{i}"
                });
                parent.Child03s.Add(new Child03
                {
                    Name = $"child{i}"
                });
            }
            ctx.SaveChanges();


        }
        public static void GetParentIncludeChildSplitedQuery()
        {
            var ctx = ContextFactory.GetSqlContext();
            var parentQuery = ctx.Parent.AsSplitQuery()
                .Include(c => c.Child01s)
                .Include(c => c.Child02s)
                .Include(c => c.Child03s)
                .AsQueryable();

            var queryText = parentQuery.ToQueryString();
            var result = parentQuery.ToList();

            ////optionsBuilder.UseSqlServer("Password=239;Persist Security Info=True;User ID=sa;Initial Catalog=Store;Data Source=.",
            ////c => c.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }










    }
}
