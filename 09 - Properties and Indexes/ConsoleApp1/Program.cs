class Program
{
    static void Main()
    {
        // will create class based on constructor only
        Employee emp1 = new Employee(1, "John Doe", "plumber");
        Employee emp2 = new Employee(2, "Joseph Richards", "product owner");

        Employee emp3 = new Employee();
        // will pass through properties valutation, therefore name will be null
        emp3.Id = 3;
        emp3.Name = "A";
        emp3.Job = "Software Engineer";

        System.Console.WriteLine("Welcome to " + Employee.CompanyName);

        System.Console.WriteLine("ID: " + emp1.Id);
        System.Console.WriteLine("Name: " + emp1.Name);
        System.Console.WriteLine("Job: " + emp1.Job);
        System.Console.WriteLine();

        System.Console.WriteLine("ID: " + emp2.Id);
        System.Console.WriteLine("Name: " + emp2.Name);
        System.Console.WriteLine("Job: " + emp2.Job);

        System.Console.WriteLine();
        System.Console.WriteLine("ID: " + emp3.Id);
        System.Console.WriteLine("Name: " + emp3.Name);
        System.Console.WriteLine("Job: " + emp3.Job);

        System.Console.ReadKey();
    }
}