using HR.Manager;
// using HR.Manager = AliasExample
using static System.Console;



class Program
{
    static void Main()
    {
        ExecutiveManager executiveManager = new ExecutiveManager();
        AssistantManager assistantManager = new AssistantManager();
        WriteLine("Example of static namespace");
        ReadKey();
    }
}