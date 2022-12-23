using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExample
{

    class Person
    {
        public string Name { get; set; }
    }

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

            // First example
            Employee firstExample = employees.First(employee => employee.Job == "Developer");
            Console.WriteLine("\nFirst example: ");
            Console.WriteLine(firstExample.Id + ", " + firstExample.Name + ", " + firstExample.City + ", " + firstExample.Job + ", " + firstExample.Salary);

            // run-time error if no matching element is accessed
            // should use first or default
            Employee firstOrDefaultExample = employees.FirstOrDefault(employee => employee.Job == "Product owner");
            Console.WriteLine("\nFirstOrDefault example: ");
            if (firstOrDefaultExample != null)
            {
                Console.WriteLine(firstOrDefaultExample.Id + ", " + firstOrDefaultExample.Name + ", " + firstOrDefaultExample.City + ", " + firstOrDefaultExample.Job + ", " + firstOrDefaultExample.Salary);
            }
            else
            {
                Console.WriteLine("No matching elments");
            }

            // Last example
            Employee lastExample = employees.Last(employee => employee.Job == "Developer");
            Console.WriteLine("\nLast example: ");
            Console.WriteLine(lastExample.Id + ", " + lastExample.Name + ", " + lastExample.City + ", " + lastExample.Job + ", " + lastExample.Salary);

            // run-time error if no matching element is accessed
            // should use LastOrDefault
            Employee lastOrDefaultExample = employees.LastOrDefault(employee => employee.Job == "Product owner");
            Console.WriteLine("\nLastOrDefault example: ");
            if (lastOrDefaultExample != null)
            {
                Console.WriteLine(lastOrDefaultExample.Id + ", " + lastOrDefaultExample.Name + ", " + lastOrDefaultExample.City + ", " + lastOrDefaultExample.Job + ", " + lastOrDefaultExample.Salary);
            }
            else
            {
                Console.WriteLine("No matching elments");
            }

            // ElementAt example
            // throws error if index dont exist
            Employee elementAtExample = employees.ElementAt(2);
            Console.WriteLine("\nElementAt example: ");
            Console.WriteLine(elementAtExample.Id + ", " + elementAtExample.Name + ", " + elementAtExample.City + ", " + elementAtExample.Job + ", " + elementAtExample.Salary);

            // ElementAtOrDefault
            // returns null if index dont exist
            // throws exception if tries to access null properties
            Employee elementAtOrDefaultExample = employees.ElementAtOrDefault(20);
            Console.WriteLine("\nElementAtOrDefault example: ");
            if (elementAtOrDefaultExample != null)
            {
                Console.WriteLine(elementAtOrDefaultExample.Id + ", " + elementAtOrDefaultExample.Name + ", " + elementAtOrDefaultExample.City + ", " + elementAtOrDefaultExample.Job + ", " + elementAtOrDefaultExample.Salary);
            }
            else
            {
                Console.WriteLine("no element match");
            }

            // Single example
            // throws exception if collection contains no or more than one matching element
            Employee singleExample = employees.Single(employee => employee.City == "Jundiai");
            Console.WriteLine("\nSingle example: ");
            Console.WriteLine(singleExample.Id + ", " + singleExample.Name + ", " + singleExample.City + ", " + singleExample.Job + ", " + singleExample.Salary);

            // Select example
            List<Person> selectExample = employees.Select(emp => new Person() { Name = emp.Name }).ToList();

            Console.WriteLine("\nSelect example: ");
            foreach (Person item in selectExample)
            {
                Console.WriteLine(item.Name);
            }

            // Min, Max, Sum, Average, Count
            Console.WriteLine("Min salary: " + employees.Min(emp => emp.Salary));
            Console.WriteLine("Max salary: " + employees.Max(emp => emp.Salary));
            Console.WriteLine("Sum salary: " + employees.Sum(emp => emp.Salary));
            Console.WriteLine("Average salary: " + employees.Average(emp => emp.Salary));
            Console.WriteLine("Count salary: " + employees.Count());


            Console.ReadKey();
        }
    }
}
