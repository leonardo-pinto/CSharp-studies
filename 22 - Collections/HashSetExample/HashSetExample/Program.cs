using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create an object of HashSet
            HashSet<string> messages = new HashSet<string>()
            {
                "Good Morning", "How Are You", "Have a good day"
            };

            //foreach
            foreach(string message in messages)
            {
                Console.WriteLine(message);
            };

            // add
            messages.Add("Good Luck");

            // remove based on value
            messages.Add("Good Morning");

            // RemoveWhere
            messages.RemoveWhere(m => m.EndsWith("u"));


            Console.WriteLine("Count: " + messages.Count());


            // perform union
            HashSet<string> employees2021 = new HashSet<string>()
            {
                "Amar", "Akhil", "Samareen"
            };

            HashSet<string> employees2022 = new HashSet<string>()
            {
                "John", "Joseph", "Amar"
            };

            // union
            employees2021.UnionWith(employees2022);
            foreach(string employee in employees2021)
            {
                Console.WriteLine(employee);
            };

            // intersection
            employees2021.IntersectWith(employees2022);
            foreach (string employee in employees2021)
            {
                Console.WriteLine("Intersection");
                Console.WriteLine(employee);
            };

            Console.ReadKey();
        }
    }
}
