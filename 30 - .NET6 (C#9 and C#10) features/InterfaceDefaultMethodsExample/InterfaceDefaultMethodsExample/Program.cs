public interface IEmployee
{
    public string Name { get; set; }

    public string GetNameInUpperCase()
    {
        return Name.ToUpper();
    }
}

public class Manager: IEmployee
{
    private string? _name;

    public string? Name { get; set; }
}

public class Clerk: IEmployee
{
    private string? _name;

    public string? Name { set; get; }
}

class Program
{
    static void Main()
    {
        Manager manager = new();
        manager.Name = "Josias";
        Clerk clerk = new();
        clerk.Name = "John";

        IEmployee iEmpManager = (IEmployee)manager;
        IEmployee iEmpClerk = (IEmployee)clerk;

        Console.WriteLine(iEmpManager.GetNameInUpperCase());
        Console.WriteLine(iEmpClerk.GetNameInUpperCase());
    }
}