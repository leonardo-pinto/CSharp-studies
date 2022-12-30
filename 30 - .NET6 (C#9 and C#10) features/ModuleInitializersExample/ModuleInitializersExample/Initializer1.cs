using System.Runtime.CompilerServices;

internal class Initializer1
{
    // can create a single initializer file
    // which calls other methods


    [ModuleInitializer]
    internal static void Init2()
    {
        Console.WriteLine("Init 2 executed");
    }

    [ModuleInitializer]
    internal static void Init1()
    {
        Console.WriteLine("Init 1 executed");
    }

}
