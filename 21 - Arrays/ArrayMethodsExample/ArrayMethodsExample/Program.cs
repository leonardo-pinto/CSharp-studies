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
            // example of IndexOf
            Console.WriteLine("IndexOf 2: " + Array.IndexOf(numbersArray, 2));
            Console.WriteLine("Unexistent indexOf: " + Array.IndexOf(numbersArray, 50));
            
            // example of BinarySearch
            // can only be used in sorted arrays
            Console.WriteLine(Array.BinarySearch(numbersArray, 3));

            // example of Clear method
            int[] arrayToBeCleared = new int[5] { 1, 2, 3, 4, 5 };
            Array.Clear(arrayToBeCleared, 2, 3);
            
            foreach (int element in arrayToBeCleared)
            {
                Console.WriteLine(element);
            }

            // example of Resize method
            // increase/decrease array with null values
            int[] resizeExample = new int[2] { 1, 2 };
            Array.Resize(ref resizeExample, 5);

            foreach (int element in resizeExample)
            {
                Console.WriteLine(element);
            }
            
            Console.ReadKey();
        }
    }
}
