using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create a HashTable
            // not generic
            // needs to specify type in method, but no in construction
            Hashtable employees = new Hashtable()
            {
                { 101, "John Doe" },
                { "stringKey", 1 }
            };

            employees.Add("anotherKey", "anotherValue");

            // foreach
            foreach (DictionaryEntry employee in employees)
            {
                Console.WriteLine(employee.Key + " " + employee.Value);
            };

            // get value based on key
            if (employees[101 ] is string)
            {
                string value = Convert.ToString(employees[101]);
                Console.WriteLine(value);

            };

            Console.ReadKey();

        }
    }
}
