using System;

namespace ArrayMethodsExample
{
    internal class Program
    {
        static void Main()
        {
            // create array
            int[] numbersArray = new int[3] {1, 2, 3};

            // search for 2 in the array
            Console.WriteLine("IndexOf 2: " + Array.IndexOf(numbersArray, 2));
            Console.WriteLine("Unexistent indexOf: " + Array.IndexOf(numbersArray, 50));
            Console.ReadKey();
        }
    }
}
