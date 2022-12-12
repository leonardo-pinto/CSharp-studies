public class Employee
{
    public int salary;
}

public class Manager
{
    public int tax;
}

// a class with a generic method
public class Sample
{
    // generic method
    public void PrintData<T>(T obj) where T : class
    {
        if (obj.GetType() == typeof(Employee))
        {
            Employee employee = obj as Employee;
            System.Console.WriteLine(employee.salary);
        } else if (obj.GetType() == typeof(Manager))
        {
            Manager manager = obj as Manager;
            System.Console.WriteLine(manager.tax);
        }
    }
}
