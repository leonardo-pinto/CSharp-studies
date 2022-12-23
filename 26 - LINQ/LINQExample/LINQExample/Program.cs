using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExample
{
    class Employee
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            // collection of objects
            List<Employee> employees = new List<Employee>()
            { 
                new Employee(){ Id = 1, Name = "Joseph", City = "Botucatu", Job = "Manager", Salary = 1000 },
                new Employee(){ Id = 2, Name = "John Doe", City = "Dallas", Job = "Developer", Salary = 5000 },
                new Employee(){ Id = 3, Name = "Zé Urso", City = "Botucatu", Job = "Developer", Salary = 3000 },
                new Employee(){ Id = 4, Name = "Leonardo", City = "Jundiai", Job = "Analyst", Salary = 750 },
                new Employee(){ Id = 5, Name = "Josephina", City = "Avaré", Job = "QA", Salary = 1500 },
            };

            IEnumerable<Employee> result = employees.Where(employee => employee.City == "Botucatu");

            // where example
            Console.WriteLine("\nWhere example: ");
            foreach (Employee employee in result)
            {
                Console.WriteLine(employee.Id + ", " + employee.Name + ", " + employee.City + ", " + employee.Job);
            }

            // OrderyBy example
            // descending: OrderByDescending()
            IOrderedEnumerable<Employee> orderBySalary = employees.OrderBy(emp => emp.Salary);
            Console.WriteLine("\nOrderBy example: ");
            foreach (Employee employee in orderBySalary)
            {
                Console.WriteLine(employee.Id + ", " + employee.Name + ", " + employee.City + ", " + employee.Job + ", " + employee.Salary);
            }

            // using second ordering parameter
            // ThenBy
            IOrderedEnumerable<Employee> orderByJob = employees.OrderBy(emp => emp.Job).ThenBy(emp => emp.Salary);
            Console.WriteLine("\nOrderBy and ThenBy example: ");
            foreach (Employee employee in orderByJob)
            {
                Console.WriteLine(employee.Id + ", " + employee.Name + ", " + employee.City + ", " + employee.Job + ", " + employee.Salary);
            }

            Console.ReadKey();
        }
    }
}
