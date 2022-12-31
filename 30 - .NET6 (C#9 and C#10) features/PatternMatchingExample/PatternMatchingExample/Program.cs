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
        //if (person.GetType() == typeof(Manager))
        //{
        //    Employee emp = (Employee)person;
        //    return $"{person.Name}, {person.Age}, {emp.Salary}";
        //}

        // type pattern matching
        //if (person is Manager manager)
        //{
        //    return $"{manager.Name}, {manager.Age}, {manager.Salary}";
        //}
        //else
        //{
        //    return $"{person.Name}, {person.Age}";
        //}

        // switch pattern

        //switch(person)
        //{
        //    case Employee emp:
        //        return $"{person.Name}, {person.Age}, {emp.Salary}";
        //    case Supplier sup when(sup.SupplierBalance > 10000):
        //        return $"{person.Name}, {person.Age}, {sup.SupplierBalance}";
        //    case Customer cus:
        //        return $"{person.Name}, {person.Age}, {cus.CustomerBalance}";
        //    default:
        //        return $"{person.Name}, {person.Age}";
        //}
        // switch expression to improve
        return person switch
        {
            Manager man when (man.Salary > 1000) => $"{person.Name}, {person.Age}, {man.Salary}",
            Employee emp => $"{person.Name}, {person.Age}, {emp.Salary}",
            Supplier sup when (sup.SupplierBalance > 10000) => $"{person.Name}, {person.Age}, {sup.SupplierBalance}",
            Customer cus => $"{person.Name}, {person.Age}, {cus.CustomerBalance}",
            _ => $"{person.Name}, {person.Age}",
        };
    }
}

class Program
{
    static void Main()
    {
        Manager manager = new() { Name = "John", Age = 45, Salary = 1500 };
        Supplier supplier = new() { Name = "John", Age = 45, SupplierBalance = 120000 };
        Console.WriteLine(Descripter.GetDescription(manager));
        Console.WriteLine(Descripter.GetDescription(supplier));

        Console.ReadKey();
    }
}

