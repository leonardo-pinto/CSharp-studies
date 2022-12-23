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
            Console.WriteLine("Replace: " + str.Replace("e", "a")); // Davalopar
            string[] strSplit = str.Split('e');
            Console.WriteLine("Split: ");
            foreach(string item in strSplit)
            {
                Console.WriteLine(item);
            }

            string trimExample = "   hello   ";
            string trimResult = trimExample.Trim();
            Console.WriteLine("Trim: " + trimResult);

            string toCharArrayExample = "any string";
            char[] toCharArrayResult = toCharArrayExample.ToCharArray();
            Console.WriteLine("ToCharArray:");
            foreach (char item in toCharArrayResult)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
