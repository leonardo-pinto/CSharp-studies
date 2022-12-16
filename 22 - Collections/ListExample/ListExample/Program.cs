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

            // Add method
            myList.Add(4);

            // AddRange method
            List<int> listToBeAdded = new List<int>() { 5, 6, 7 };
            myList.AddRange(listToBeAdded);

            // Insert method
            // (int, newValue)
            myList.Insert(0, 0);

            // InsertRange
            List<int> listToBeInsertedRange = new List<int>() { 10, 20 };
            myList.InsertRange(1, listToBeInsertedRange);

            // Remove method
            myList.Remove(0);

            // RemoveAt method
            // run-time error if index does not exist
            if (100 < myList.Count)
            {
                myList.RemoveAt(100);
            }

            // RemoveRange method
            myList.RemoveRange(0, 3);

            // RemoveAll method
            // uses a lambda expression
            myList.RemoveAll(n => n >= 6);

            // Clear method
            // myList.Clear();

            // IndexOf method
            // returns -1 if not found
            // performs linear search
            // stops at first occurance
            Console.WriteLine("(IndexOf) Index of value 5 is: " + myList.IndexOf(5));

            // BinarySearch method
            // List must be sorted
            // Better performance for large Lists
            List<int> binarySearchExample = new List<int>() { 1, 2, 3, 4, 5, 6 };
            int binarySearchIndex = binarySearchExample.BinarySearch(2);
            Console.WriteLine("(BinarySearch) Index of value 2 is: " + binarySearchIndex);

            // Contains method
            Console.WriteLine("myList contains value 70? " + myList.Contains(80));
            Console.WriteLine("myList contains value 5? " + myList.Contains(5));

            // Sort method
            // ascending order
            //myList.Sort();

            // Reverse method
            //myList.Reverse();

            foreach (int element in myList)
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }
}
