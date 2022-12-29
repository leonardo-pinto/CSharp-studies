// Top level statement removes the necessity of using Main method
// ReadKey is automatic

// top level statements are internally converted
// to the regular syntax
//public class Program
//{
//    static void Main()
//    {
//        ...
//    }
//}


Console.WriteLine("Hello, World!");
string name = "Leonardo";

Console.WriteLine($"My name is {name}");

namespace namespace1
{
    class Sample
    {
        public void Method1()
        {
            // top level statement variables are local
            //string str = name;
        }
    
    }
}
