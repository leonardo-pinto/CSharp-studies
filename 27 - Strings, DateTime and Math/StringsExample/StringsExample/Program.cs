using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsExample
{
    internal class Program
    {
        static void Main()
        {
            string str = "Developer";

            Console.WriteLine("Initial string: " + str);
            Console.WriteLine("ToUpper: " + str.ToUpper()); // DEVELOPER
            Console.WriteLine("ToLower: " + str.ToLower()); // developer
            Console.WriteLine("Substring: " + str.Substring(1, 3)); // eve

            Console.ReadKey();
        }
    }
}
