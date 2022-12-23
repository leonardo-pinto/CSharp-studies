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
    }

    internal class Program
    {
        static void Main()
        {
            // collection of objects
            List<Employee> employees = new List<Employee>()
            { 
                new Employee(){ Id = 1, Name = "Joseph", City = "Botucatu", Job = "Manager"},
                new Employee(){ Id = 2, Name = "John Doe", City = "Dallas", Job = "Developer"},
                new Employee(){ Id = 3, Name = "Zé Urso", City = "Botucatu", Job = "Developer"},
                new Employee(){ Id = 4, Name = "Leonardo", City = "Jundiai", Job = "Analyst"},
                new Employee(){ Id = 5, Name = "Josephina", City = "Avaré", Job = "QA"},
            };

            IEnumerable<Employee> result = employees.Where(employee => employee.City == "Botucatu");

            foreach(Employee employee in result)
            {
                Console.WriteLine(employee.Id + ", " + employee.Name + ", " + employee.City + ", " + employee.Job);
            }
            Console.ReadKey();
        }
    }
}
