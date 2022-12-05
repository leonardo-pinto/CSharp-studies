class Program
{
    static void Main()
    {
        Employee emp1 = new Employee(1, "John Doe", "plumber");
        Employee emp2 = new Employee(2, "Joseph Richards", "product owner");

        System.Console.WriteLine("First Employee: ");
        System.Console.WriteLine("ID: " + emp1.id);
        System.Console.WriteLine("Name: " + emp1.name);
        System.Console.WriteLine("Job: " + emp1.job);
        System.Console.WriteLine();

        System.Console.WriteLine("Second Employee: ");
        System.Console.WriteLine("ID: " + emp2.id);
        System.Console.WriteLine("Name: " + emp2.name);
        System.Console.WriteLine("Job: " + emp2.job);

        System.Console.ReadKey();
    }
}