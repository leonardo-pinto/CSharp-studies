using System;
using System.Collections.Generic;

namespace ListExample
{
    internal class Program
    {
        static void Main()
        {
            // create reference variable for List class
            // and create object of List class

            // number 10 represents the initial list capacity
            // therefore, until list has 10 elements, list is
            // not reconstructed
            List<int> myList = new List<int>(10) { 1, 2, 3 };

            foreach(int element in myList)
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }
}
