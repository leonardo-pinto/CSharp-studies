using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableExample
{
    public class Employee: IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(object other)
        {
            // sort based on a string value
            return this.Name.CompareTo(((Employee)other).Name);

            // sort based on a int value
            //Console.WriteLine(this.Id+ " " + ((Employee)other).Id);
            //return this.Id - ((Employee)other).Id;
        }
    }

    internal class Program
    {
        static void Main()
        {
            // list of employees
            List<Employee> employees = new List<Employee>()
            {
                new Employee(){Id = 15, Name = "Joseph" },
                new Employee(){Id = 1, Name = "Adelaide" },
                new Employee(){Id = 87, Name = "Richmond" },
            };

            employees.Sort();

            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee.Id + ", " + employee.Name);
            }

            Console.ReadKey();
        }
    }
}
