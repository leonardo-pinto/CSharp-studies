using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSubtractionExample
{
    class Employee
    {
        public string Name { get; set; }
        public DateTime DateOfJoining { get; set; }
        public double ExperienceYears { get; set; }
        public double ExperienceMonths { get; set; }
        
    }
    internal class Program
    {
        static void Main()
        {
            Employee employee = new Employee() { Name = "Joseph Richards", DateOfJoining = DateTime.Parse("2015-01-01")};

            DateTime today = DateTime.Now;
            
            // CompareTo method
            // 0 -> same date; 1 -> date is later than; -1 -> date is earlier than
            if (today.CompareTo(employee.DateOfJoining) == 1)
            {
                TimeSpan result = today.Subtract(employee.DateOfJoining);
                employee.ExperienceYears = Math.Floor(result.TotalDays / 365);
                employee.ExperienceMonths = (result.TotalDays - (employee.ExperienceYears * 365)) / 30;
                
                Console.WriteLine(employee.ExperienceYears);
                Console.WriteLine(employee.ExperienceMonths);
   
            }
            else
            {
                Console.WriteLine("Date of joining is greater than today's date. It is not possible to subtract");
            }

            Console.ReadKey();
        }
    }
}
