using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparerExample
{

    // scenario when it is not possible to implement IComparable interface
    // to the current model class
    public class Employee
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
    }

    public enum SortBy
    {
        Id, Name, Job
    }

    public class CustomComparer : IComparer<Employee>
    {
        public SortBy SortBy { get; set; }
        public int Compare(Employee x, Employee y)
        {
            // based com selection properties
            int comparison = 0;
            switch (this.SortBy)
            {
                case SortBy.Id:
                    comparison = x.Id - y.Id; break;
                case SortBy.Name:
                    comparison = (x.Name != null) ? x.Name.CompareTo(y.Name) : 0; break;
                case SortBy.Job:
                    comparison = (x.Job != null) ? x.Job.CompareTo(y.Job) : 0; break;
                default:
                    comparison = 0; break;
            }

            return comparison;


            // based on two string parameters
            //int comparison = 0;
            //if (x.Job != null)
            //{
            //    comparison = x.Job.CompareTo(y.Job); // first sorting column
            //}

            //if (comparison == 0)
            //{
            //    if (x.Name!= null)
            //    {
            //        comparison = x.Name.CompareTo(y.Name);
            //    }
            //}

            //return comparison;

            // based on string
            //return x.Name.CompareTo(y.Name);

            // based on int
            //return x.Id - y.Id;
        }
    }

    internal class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee(){ Id = 2, Name = "Joseph", Job = "Biologist" },
                new Employee(){ Id = 43, Name = "Richards", Job = "Physicist" },
                new Employee(){ Id = 1, Name = "Zé Urso", Job = "Biologist"}
            };

            CustomComparer customComparer = new CustomComparer();
            customComparer.SortBy = SortBy.Name;
            employees.Sort(customComparer); // specify field
           

            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee.Id + ", " + employee.Name + ", " + employee.Job);
            }

            Console.ReadKey();
        }
    }
}
