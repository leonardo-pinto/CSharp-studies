class Program
{
    static void Main()
    {
        Manager manager1 = new Manager(1, "John Doe", "New York");
        System.Console.WriteLine("Manager 1: ");
        System.Console.WriteLine("ID: " + manager1.Id);
        System.Console.WriteLine("Name: " + manager1.Name);
        System.Console.WriteLine("Location: " + manager1.Location);
        System.Console.WriteLine("Health Insurance: " + manager1.GetHealthInsuranceAmount());

        System.Console.WriteLine();

        Salesman salesman1 = new Salesman(2, "Joseph Richards", "Toronto");
        System.Console.WriteLine("Salesman 1: ");
        System.Console.WriteLine("ID: " + salesman1.Id);
        System.Console.WriteLine("Name: " + salesman1.Name);
        System.Console.WriteLine("Location: " + salesman1.Location);
        System.Console.WriteLine("Health Insurance: " + salesman1.GetHealthInsuranceAmount());


        System.Console.ReadKey();
    }
}