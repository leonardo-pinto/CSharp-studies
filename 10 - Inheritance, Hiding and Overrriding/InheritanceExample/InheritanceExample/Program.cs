﻿class Program
{
    static void Main()
    {
        // create object of Employee
        Employee emp1 = new Employee
        {
            Id = "1",
            Name = "John Doe",
            Location = "Sao Paulo",
        };

        System.Console.WriteLine("Object of Parent class (Employee)");
        System.Console.WriteLine(emp1.Id);
        System.Console.WriteLine(emp1.Name);
        System.Console.WriteLine(emp1.Location);
        System.Console.WriteLine();

        // create object of Manager
        Manager man1 = new Manager
        {
            Id = "2",
            Name = "Joseph Richards",
            Location = "New York",
            DepartmentName = "LA Banks"
        };

        System.Console.WriteLine("Object of Child class (Manager)");
        System.Console.WriteLine(man1.Id);
        System.Console.WriteLine(man1.Name);
        System.Console.WriteLine(man1.Location);
        System.Console.WriteLine(man1.DepartmentName);
        System.Console.WriteLine(man1.GetTotalSalesOfYear());
        System.Console.WriteLine();

        // create object of SalesMan
        SalesMan sal1 = new SalesMan
        {
            Id = "3",
            Name = "Leonardo Pinto",
            Location = "Toronto",
            Region = "Latin America"
        };

        System.Console.WriteLine("Object of Child class (Manager)");
        System.Console.WriteLine(sal1.Id);
        System.Console.WriteLine(sal1.Name);
        System.Console.WriteLine(sal1.Location);
        System.Console.WriteLine(sal1.Region);
        System.Console.WriteLine(sal1.GetSalesOfCurrentMonth());
        System.Console.WriteLine();
        System.Console.ReadKey();
    }
}