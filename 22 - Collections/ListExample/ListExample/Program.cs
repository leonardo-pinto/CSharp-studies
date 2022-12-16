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


            foreach(int element in myList)
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }
}
