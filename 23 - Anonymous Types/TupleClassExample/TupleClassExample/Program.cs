using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupleClassExample
{
    class Sample
    {
        // if we want to return multiple values from one method,
        // we have the following options
        // 1) Create a separate class with the properties
        // 2) Use anonymous objects
        // 3) Use Out type of parameters
        // 4) Use of tuples
        // 5) Use of values tuples (next lesson)
        public Tuple<string,int> GetPersonDetails()
        {
            Tuple<string, int> person = new Tuple<string, int>("Scott", 20);
            return person;
        }
    }


    internal class Program
    {
        static void Main()
        {
            Sample sample = new Sample();
            Tuple<string,int> tuple = sample.GetPersonDetails();

            // access values from tuple
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item2);

            Console.ReadKey();
        }
    }
}
