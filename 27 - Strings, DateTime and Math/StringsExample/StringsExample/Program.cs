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


            string[] words = new string[] { "Hello", ",", "how", "are", "you", "?" };
            // call Join with String.Join() because it is a static method
            Console.WriteLine("Join: " + string.Join("-", words));

            string str1 = "Universe";
            string str2 = "Universe";
            Console.WriteLine("Equals example");
            Console.WriteLine("Is " + str1 + " and " + str2 + " equal? " + str1.Equals(str2));
            Console.WriteLine(str1 == str2);

            // We can overload .Equals method to consider objects

            Console.WriteLine("Does " + str1 + " starts with U? " + str1.StartsWith("U"));
            Console.WriteLine("Does " + str1 + " starts with x? " + str1.StartsWith("x"));

            Console.WriteLine("Does " + str1 + " ends with e? " + str1.EndsWith("e"));
            Console.WriteLine("Does " + str1 + " ends with f? " + str1.EndsWith("f"));

            Console.WriteLine("Does " + str1 + "contains s? " + str1.Contains("s"));
            Console.WriteLine("Does " + str1 + "contains u? " + str1.Contains("u"));

            Console.WriteLine("IndexOf 'e' in Universe: " + str1.IndexOf("e"));
            Console.WriteLine("IndexOf 'z' in Universe: " + str1.IndexOf("e"));
            Console.WriteLine("IndexOf 'e' in Universe starting from element 5: " + str1.IndexOf("e", 5));


            // static method is called from the class
            // use IsNullOrEmpty in the set accessor
            Console.WriteLine("Is " + str1 + " null of empty?: " + string.IsNullOrEmpty(str1));
            // isNullOrWhiteSpace
            // allows spaces value

            // example of string interpolation
            string name = "Leonardo";
            string message = $"My name is {name}";
            Console.WriteLine(message);
            Console.WriteLine($"Using interpolate strings, my name is {name}");

            // Modifying strings
            // Insert method
            Console.WriteLine($"Modified Leonardo: {name.Insert(2, "abluble")}");
            // Remove method
            Console.WriteLine($"Remove modified Leonardo: {name.Remove(3, 4)}");
            Console.ReadKey();
        }
    }
}
