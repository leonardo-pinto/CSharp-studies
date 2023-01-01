public interface IEmployee
{
    public string Name { get; set; }

    internal string GetNameInLowerCase();

    internal int GetNameLength();

    // static method
    public static string GetNameTitle()
    {
        return "Mr./Ms.";
    }
}

public class Manager: IEmployee
{
    private string _name;
    public string Name { get => _name; set => _name = value; }


    // When interface method is not public
    // Option 1: You can explicitly implement non-public abstract interface methods
    string IEmployee.GetNameInLowerCase()
    {
        return _name.ToLower();
    }


    // Option 2: You can convert the non-public abstract method into public
    public int GetNameLength()
    {
        return _name.Length;
    }
}

class Program
{
    static void Main()
    {
        Manager manager = new() { Name = "Johnson" };
        // when the implementation is not public
        // cannot call through the class intance
        IEmployee iEmpManager = (IEmployee)manager;

        Console.WriteLine(iEmpManager.GetNameInLowerCase());
        Console.WriteLine(manager.GetNameLength());
        Console.WriteLine(IEmployee.GetNameTitle());
    }
}