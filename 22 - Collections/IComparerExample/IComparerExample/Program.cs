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
    }

    public class CustomComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Id - y.Id;
        }
    }

    internal class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee(){ Id = 2, Name = "Joseph" },
                new Employee(){ Id = 43, Name = "Richards" },
                new Employee(){ Id = 1, Name = "Zé Urso"}
            };

            CustomComparer customComparer = new CustomComparer();

            employees.Sort(customComparer);
            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee.Id + ", " + employee.Name);
            }

            Console.ReadKey();
        }
    }
}
