using System;
using System.Collections.Generic;

namespace DictionaryExample
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<int, string> employees = new Dictionary<int, string>()
            {
                { 101, "Scott" },
                { 102, "John Doe" },
                { 103, "Joseph Richards" }
            };

            // foreach loop for dictionary
            foreach (KeyValuePair<int, string> employee in employees)
            {
                Console.WriteLine(employee.Key + ", " + employee.Value);
            };

            // Keys
            Dictionary<int, string>.KeyCollection keys = employees.Keys;
            Console.WriteLine("\nKeys:");
            foreach(int key in keys)
            {
                Console.WriteLine(key);
            }

            // get value based on key
            Console.WriteLine("Value for key 101: " + employees[101]);

            // duplicate key exception
            //employees.Add(101, "Anna");

            // Remove method example
            employees.Remove(102);

            Console.WriteLine("\nKeys:");
            foreach (int key in keys)
            {
                Console.WriteLine(key);
            };

            // ContainsKey method
            Console.WriteLine("Does 101 key exists? " + employees.ContainsKey(101));

            Console.ReadKey();
        }
    }
}
