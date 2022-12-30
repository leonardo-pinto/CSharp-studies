class Person
{
    // allow null values
    public string? Name { get; set; }
    public int? Age { get; set; }
}

class Employee : Person
{
    public double? Salary { get; set; }
}

class Customer: Person
{
    public double? CustomerBalance { get; set; }
}

class Supplier: Person
{
    public double? SupplierBalance { get; set; }
}

class Manager: Employee
{
}

class Descripter
{
    public static string GetDescription(Person person)
    {
        // must specify for each type of input e.g. Customer, Supplier, Manager
        if (person.GetType() == typeof(Manager))
        {
            Employee emp = (Employee)person;
            return $"{person.Name}, {person.Age}, {emp.Salary}";
        }
        else
        {
            return $"{person.Name}, {person.Age}";
        }
    }
}

class Program
{
    static void Main()
    {
        Manager manager = new() { Name = "John", Age = 45, Salary = 1500 };
        Supplier supplier = new() { Name = "John", Age = 45, SupplierBalance = 1500 };
        Console.WriteLine(Descripter.GetDescription(manager));
        Console.WriteLine(Descripter.GetDescription(supplier));
    }
}

