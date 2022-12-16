using System;

namespace DeepCopyExample
{
    // model class
    class Employee
    {
        public string Name { get; set; }
        public string Role { get; set; }

        public Employee Clone()
            // C# recommendation is to name method as Clone
        {
            return new Employee() { Name = this.Name, Role = this.Role }
        }
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

            // deep copy implementation
            Employee[] employeeDeepCopy = new Employee[employees.Length];
            for (int i = 0; i < employees.Length; i++)
            {
                Employee result = employees[i].Clone();
                employeeDeepCopy[i] = result;
            }
            Console.WriteLine("Deep copy example");
            foreach(Employee employee in employeeDeepCopy)
            {
                if (employee != null)
                {
                    Console.WriteLine(employee.Name + ", " + employee.Role);
                }
            }

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
            foreach (Employee employee in highlyPaidEmployees)
            {
                if (employee != null)
                {
                    Console.WriteLine(employee.Name + ", " + employee.Role);
                }
            }

            Console.WriteLine("Clone example:");
            // Clone method
            Employee[] cloneExample = (Employee[])employees.Clone();
            foreach (Employee employee in cloneExample)
            {
                if (employee != null)
                {
                    Console.WriteLine(employee.Name + ", " + employee.Role);
                }
            }

            // if we change the copy, original object is also changed
            cloneExample[0].Name = "Clone example changed name";
            foreach (Employee employee in employees)
            {
                if (employee != null)
                {
                    Console.WriteLine(employee.Name + ", " + employee.Role);
                }
            }

            Console.WriteLine("Deep copy at last, should not be changed!");
            foreach (Employee employee in employeeDeepCopy)
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
