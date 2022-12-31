enum MaritalStatus
{
    Single, Married
}

class Person
{
    // allow null values
    public string? Name { get; set; }
    public int? Age { get; set; }
    public MaritalStatus PersonMaritalStatus { get; set; }
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
        //return person switch
        //{
        //    Manager man when (man.Salary > 1000) => $"{person.Name}, {person.Age}, {man.Salary}",
        //    Employee emp => $"{person.Name}, {person.Age}, {emp.Salary}",
        //    Supplier sup when (sup.SupplierBalance > 10000) => $"{person.Name}, {person.Age}, {sup.SupplierBalance}",
        //    Customer cus => $"{person.Name}, {person.Age}, {cus.CustomerBalance}",
        //    _ => $"{person.Name}, {person.Age}",
        //};

        // Relational and Logical pattern
        //return person switch
        //{
        //    Person p when p.Age is <= 13 => $"{person.Name} is a child",
        //    // p.Age <= 13
        //    Person p when p.Age is > 13 and <= 18 => $"{person.Name} is a teenager",
        //    // p.Age > 13 && p.Age <= 18
        //    Person p when p.Age is > 18 and < 60 => $"{person.Name} is an adult",
        //    // p.Age > 18 && p.Age < 60
        //    Person p when p.Age is >= 60 and < 100 => $"{person.Name} is a senior",
        //    // p.Age >= 60
        //    Person p when p.Age is 100 or 200 => $"{person.Name} is a centenarian",
        //    _ => $"{person.Name} is {person.Age} years old",
        //};

        // Property Pattern example
        return person switch
        {
            // first tries to cast type, then checks conditions
            // then assigns p value and return
            { Age: <= 13 } p => $"{person.Name} is a child",
            //Person p when p.Age is <= 13 => $"{person.Name} is a child",
           
            Person { Age: > 13 and <= 18 } p => $"{person.Name} is a teenager",
           
            Person { Age: > 18 and < 60, PersonMaritalStatus: MaritalStatus.Single } p => $"{person.Name} is a happy adult",
            Person { Age: > 18 and < 60, PersonMaritalStatus: MaritalStatus.Married } p => $"{person.Name} is a sad adult",

            Person { Age: >= 60 and < 100 } p => $"{person.Name} is a senior",
         
            Person { Age: 100 or 200 } p => $"{person.Name} is a centenarian",
            _ => $"{person.Name} is {person.Age} years old",
        };
    }
}

class Program
{
    static void Main()
    {
        Manager manager = new() { Name = "Leonardo", Age = 6, Salary = 1500, PersonMaritalStatus = MaritalStatus.Married };
        Supplier supplier = new() { Name = "Enzo", Age = 20, SupplierBalance = 120000, PersonMaritalStatus = MaritalStatus.Single };
        Employee emp = new() { Name = "John Doe", Age = 35, PersonMaritalStatus = MaritalStatus.Married };
        Employee emp2 = new() { Name = "Joseph Richards", Age = 100, PersonMaritalStatus = MaritalStatus.Married };
        Console.WriteLine(Descripter.GetDescription(manager));
        Console.WriteLine(Descripter.GetDescription(supplier));
        Console.WriteLine(Descripter.GetDescription(emp));
        Console.WriteLine(Descripter.GetDescription(emp2));

        Console.ReadKey();
    }
}

