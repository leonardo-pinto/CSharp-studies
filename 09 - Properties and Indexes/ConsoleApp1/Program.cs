class Program
{
    static void Main()
    {
        // will create class based on constructor only
        Employee emp1 = new Employee(1, "John Doe", "plumber", 1000);
        emp1.Tax = 5;
        emp1.Nationality = "Canada";
        Employee emp2 = new Employee(2, "Joseph Richards", "product owner", 3000);
        emp2.Tax = 12.5;
        emp2.Nationality = "USA";

        Employee emp3 = new Employee
        {
            // will pass through properties valutation, therefore name will be null
            Id = 3,
            Name = "A",
            Job = "Software Engineer",
            Tax = 3,
            Nationality = "Brazil"
        };

        System.Console.WriteLine("Welcome to " + Employee.CompanyName);

        System.Console.WriteLine("ID: " + emp1.Id);
        System.Console.WriteLine("Name: " + emp1.Name);
        System.Console.WriteLine("Nationality: " + emp1.Nationality);
        System.Console.WriteLine("Job: " + emp1.Job);
        System.Console.WriteLine("Net Salary: " + emp1.CalculateNetSalary());
        System.Console.WriteLine();

        System.Console.WriteLine("ID: " + emp2.Id);
        System.Console.WriteLine("Name: " + emp2.Name);
        System.Console.WriteLine("Job: " + emp2.Job);
        System.Console.WriteLine("Nationality: " + emp2.Nationality);
        System.Console.WriteLine("Net Salary: " + emp2.CalculateNetSalary());

        System.Console.WriteLine();
        System.Console.WriteLine("ID: " + emp3.Id);
        System.Console.WriteLine("Name: " + emp3.Name);
        System.Console.WriteLine("Job: " + emp3.Job);
        System.Console.WriteLine("Nationality: " + emp3.Nationality);
        System.Console.WriteLine("Net Salary: " + emp3.CalculateNetSalary());

        System.Console.ReadKey();
    }
}