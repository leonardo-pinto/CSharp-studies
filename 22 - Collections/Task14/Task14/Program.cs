using System;
using System.Collections.Generic;

namespace Task14
{
 
    internal class Program
    {
        public static List<int> FindLargest(List<List<int>> collections)
        {
            List<int> result = new List<int>();
            foreach (List<int> collection in collections)
            {
                collection.Sort();
                collection.Reverse();
                result.Add(collection[0]);
            }
            return result;
        }

        static void Main()
        {
            // create sample object
            List<int> largesNumbersList = FindLargest(new List<List<int>>()
            {
                new List<int>() { 67, 100, 23 },
                new List<int>() { 80, 99, 750 ,99 },
                new List<int>() { 883, 333, 9898 }
            });

            //should return new List<int>( ) { 100, 750, 9898 }

            foreach (int number in largesNumbersList)
            {
                Console.WriteLine(number);
            };

            Console.ReadKey();
        }
    }
}
