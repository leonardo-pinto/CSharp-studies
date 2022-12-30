using System.Xml.Linq;

class Employee
{
    public string Name { get; set; }
}

class EmployeeBusinessLogic
{
    public Employee? GetEmployee()
    {
        //return new Employee() { Name = "Joseph" };
        return null;
    }
}

class Program
{
    static void Main()
    {
        EmployeeBusinessLogic employeeBusinessLogic = new EmployeeBusinessLogic();
        Employee? employee = employeeBusinessLogic.GetEmployee();

        Console.WriteLine(employee?.Name);

        // or perform conditional
        if (employee != null)
        {
            Console.WriteLine(employee.Name);
        }
    }
}