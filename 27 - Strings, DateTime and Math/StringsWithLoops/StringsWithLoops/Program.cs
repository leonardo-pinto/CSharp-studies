using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsWithLoops
{
    internal class Program
    {
        static void Main()
        {
            string value = "Universe";
            int numberOfVowels = 0;
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

           foreach(char item in value.ToLower())
            {
                if (vowels.Contains(item))
                {
                    numberOfVowels++;
                }
            }

            int numberOfVowels2 = 0;

           for (int index = 0; index < value.Length; index++)
            {
                if (vowels.Contains(value.ToLower()[index]))
                {
                    numberOfVowels2++;
                }
            }
            //foreach(char item in value.ToLower())

            //{
            //    if (item == 'a' || item == 'e' || item == 'i' || item == 'o' || item == 'u')
            //    {
            //        numberOfVowels++;
            //    }
            //}

            Console.WriteLine($"Foreach -> Universe has a total of {numberOfVowels} vowels");

            Console.WriteLine($"For loop -> Universe has a total of {numberOfVowels2} vowels");

            Console.ReadKey();
        }
    }
}
