using System;

namespace ArraysExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create an array
            int[] a = new int[3] {10,20,30};

            // display element values
            //Console.WriteLine("a[0] " + a[0]);
            //Console.WriteLine("a[1] " + a[1]);

            // display elements using for loop
            Console.WriteLine("For loop");
            for (int index = 0; index < a.Length; index++)
            {
                Console.WriteLine(a[index]);
            }

            Console.WriteLine();
            // display elements using foreach loop
            Console.WriteLine("Foreach loop");
            foreach (int element in a)
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }
}
