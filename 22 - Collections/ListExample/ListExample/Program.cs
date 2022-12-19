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

            // ToArray method
            // converts to array

            List<string> toArrayExample = new List<string>() { "John Doe", "Joseph Richards" };
            string[] convertedArray = toArrayExample.ToArray();
            Console.WriteLine();
            Console.WriteLine("Example of ToArray");
            Console.WriteLine();
            foreach(string element in convertedArray)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();
            // ForEach method example
            // executes a lambda expression
            myList.ForEach(element => Console.WriteLine(element));

            //foreach (int element in myList)
            //{
            //    Console.WriteLine(element);
            //}

            // Exists method
            List<int> marks = new List<int>() { 70, 60, 80, 45, 10 };
            Console.WriteLine("Any marks below 50? " + marks.Exists(mark => mark < 50));

            // Find method
            // returns the first mathing event
            Console.WriteLine("First failed mark: " + marks.Find(mark => mark < 50));

            // FindIndex method
            // returns the indexOf the find result
            Console.WriteLine("Index of the first failed mark: " + marks.FindIndex(mark => mark < 50));

            // FindLast method
            // returns the last matching event
            Console.WriteLine("Last failed mark: " + marks.FindLast(mark => mark < 50));

            // LastIndex method
            // returns the indexOf the findLast result
            Console.WriteLine("Index of the first failed mark: " + marks.FindLastIndex(mark => mark < 50));

            // FindAll method
            // returns all matching elements
            Console.Write("All failed marks: ");
            List<int> failedMarks = marks.FindAll(mark => mark < 50);
            failedMarks.ForEach(failedMark => Console.Write(failedMark + " "));

            Console.ReadKey();
        }
    }
}
