using System;

namespace CopyAndClone
{
    // model class
    class Employee
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[]
            {
                new Employee(){Name = "John Doe", Role="Developer"},
                new Employee(){Name ="Joseph", Role="Manager"}
            };

            // new array
            Console.WriteLine("CopyTo example:");
            Console.WriteLine();
            Employee[] highlyPaidEmployees = new Employee[2];
            // CopyTo method
            employees.CopyTo(highlyPaidEmployees, 0);

            // since CopyTo and Clone performs a shallow copy
            // if we change the object it will be reflected on the new array
            employees[0].Name = "Updated name";
            // print destination array
            foreach(Employee employee in highlyPaidEmployees)
            {
                if (employee != null)
                {
                    Console.WriteLine(employee.Name + ", " + employee.Role);
                }
            }

            Console.WriteLine("Clone example:");
            // Clone method
            Employee[] cloneExample = (Employee[])employees.Clone();
            foreach(Employee employee in cloneExample)
            {
                if (employee != null)
                {
                    Console.WriteLine(employee.Name + ", " + employee.Role);
                }
            }

            // if we change the copy, original object is also changed
            cloneExample[0].Name = "Clone example changed name";
            foreach(Employee employee in employees)
            {
                if (employee != null)
                {
                    Console.WriteLine(employee.Name + ", " + employee.Role);
                }
            }

            Console.ReadKey();
        }
    }
}
