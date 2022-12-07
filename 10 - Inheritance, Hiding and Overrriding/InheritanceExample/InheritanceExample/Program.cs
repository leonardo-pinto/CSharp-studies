class Program
{
    static void Main()
    {
        // create object of Employee
        Employee emp1 = new Employee("1", "John Doe", "Sao Paulo");
        System.Console.WriteLine("Object of Parent class (Employee)");
        System.Console.WriteLine(emp1.Id);
        System.Console.WriteLine(emp1.Name);
        System.Console.WriteLine(emp1.Location);
        System.Console.WriteLine();

        // create object of Manager
        Manager man1 = new Manager("2", "Joseph Richards", "New York", "LA Banks");
        System.Console.WriteLine("Object of Child class (Manager)");
        System.Console.WriteLine(man1.Id);
        System.Console.WriteLine(man1.Name);
        System.Console.WriteLine(man1.Location);
        System.Console.WriteLine(man1.DepartmentName);
        System.Console.WriteLine(man1.GetTotalSalesOfYear());
        System.Console.WriteLine();

        // create object of SalesMan
        SalesMan sal1 = new SalesMan("3", "Leonardo Pinto", "Toronto", "North America");
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