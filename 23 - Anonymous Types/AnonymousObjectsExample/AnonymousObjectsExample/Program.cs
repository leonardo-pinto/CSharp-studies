using System;
using System.Collections.Generic;
using ClassLibrary1;

namespace AnonymousObjectsExample
{
    internal class Program
    {
        static void Main()
        {
            // create object of Person class
            Person p = new Person();

            // call methods
            //p.GetPersonName();
            //p.GetPersonAge();

            // combine both properties in the same method
            // using anonymous types
            var person = new { PersonName = p.GetPersonName(), PersonAge = p.GetPersonAge() };

            // print
            Console.WriteLine(person.PersonName);
            Console.WriteLine(person.PersonAge);

            // readonly
            person.PersonAge = 10;

            Console.ReadKey();
        }
    }
}
