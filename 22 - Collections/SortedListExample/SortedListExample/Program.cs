using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedListExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sorted Lists
            // adding time slow
            // searching time faster


            // create a SortedList
            SortedList<int, string> employees = new SortedList<int, string>()
            {
                { 101, "Scott" },
                { 102, "Smith"  },
                { 103, "Joseph" }
            };


            // add element
            employees.Add(106, "Anna");
            employees.Add(16, "Tim Hortons");

            // remove element
            employees.Remove(102);

            foreach (KeyValuePair<int, string> employee in employees)
            {
                Console.WriteLine(employee.Key + ", " + employee.Value);
            };

            // get value based on key
            Console.WriteLine(employees[106]);

            // check if a specific key exists
            Console.WriteLine("Key exists? " + employees.ContainsKey(106));
            // check if a specific value exists
            Console.WriteLine("Value exists? " + employees.ContainsValue("Scott"));

            // index of specific key
            // returns -1 if not found
            Console.WriteLine("Index of 16 key: " + employees.IndexOfKey(101));

            // index of specific value
            // returns -1 if not found
            Console.WriteLine("Index of Scott value: " + employees.IndexOfValue("Scott"));

            Console.ReadKey();
        }

    }
}
