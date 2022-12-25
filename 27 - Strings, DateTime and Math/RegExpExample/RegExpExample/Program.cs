using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegExpExample
{
    internal class Program
    {
        static void Main()
        {
            // ^ represents value beginning
            // $ represents value ending
            // only numeric values
            Regex regex = new Regex("^[0-9]*$");
            Console.WriteLine("Enter a digit: ");
            string inputValue = Console.ReadLine();
            bool result = regex.IsMatch(inputValue);
            Console.WriteLine(result);


            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Regex alphabeticRegex = new Regex("^[A-Za-z]*$");
            bool nameResult = alphabeticRegex.IsMatch(name);

            Console.WriteLine("Name is valid? " + nameResult);


            Console.ReadKey();
        }
    }
}
