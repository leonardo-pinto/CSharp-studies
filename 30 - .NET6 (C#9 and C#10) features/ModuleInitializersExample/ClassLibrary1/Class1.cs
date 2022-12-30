using System.Runtime.CompilerServices;

public class ClassInitializer
{
    [ModuleInitializer]
    internal static void Init2()
    {
        Console.WriteLine("Class initializer");
    }
}