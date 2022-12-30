class Employee
{
    // when declaring prooperty without nullable
    // there are three options
    // 1. Declare in the constructor
    // 2. Declare empty value in property declaration

    public string Name { get; set; } = "default string";
    public string LastName { get; set; } = "default";
    public int Age { get; set; }

    // use ? if can accept null value
    public AddressDetails? PersonAddressDetails { get; set; }
    public Employee()
    {
        Name = "any";
    }
}

internal class EmployeeBusinessLogic
{
    public Employee? GetEmployee()
    {
        return new Employee();
    }
}

class AddressDetails
{
    public string? City { get; set; }
    public int ZipCode { get; set; }
}

class Program
{
    static void Main()
    {
        EmployeeBusinessLogic businessLogic = new EmployeeBusinessLogic();
        Employee? employee = businessLogic.GetEmployee();

        bool isValid = employee == null;

        if (isValid)
        {
            Console.WriteLine("employee is null");
        }
        else

        {
            Console.WriteLine(employee!.Name);
            Console.WriteLine(employee!.LastName.ToLower());
            Console.WriteLine(employee!.PersonAddressDetails?.City);
        }
    }
}