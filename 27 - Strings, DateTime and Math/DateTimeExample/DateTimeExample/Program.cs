using System;
using System.Collections.Generic;


namespace DateTimeExample
{
    class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            Person person = new Person()
            {
                Name = "Joseph",
                // DateTime.Parse receives a string an return a DateTipe
                // Convert.ToDateTime is an alternative to the next one
                DateOfBirth = DateTime.Parse("2000-12-31")
            };

            Console.WriteLine($"Name: {person.Name} - Date of Birth: {person.DateOfBirth}");
            Console.WriteLine($"Day: {person.DateOfBirth.Day}");
            Console.WriteLine($"Month: {person.DateOfBirth.Month}");
            Console.WriteLine($"Year: {person.DateOfBirth.Year}");
            Console.WriteLine($"Day of week: {DateTime.Parse("2022-12-24").DayOfWeek}");
            Console.WriteLine($"Now: {DateTime.Now}");


            Console.WriteLine("********* DateTime Formats *********");
            DateTime timeExample = DateTime.Parse("2020-12-31 11:59:59.999");
    
            // values depends on windows configuration
            Console.WriteLine("ToString: " + timeExample.ToString());
            Console.WriteLine("ToShortDateString: " + timeExample.ToShortDateString());
            Console.WriteLine("ToLongDateString: " + timeExample.ToLongDateString());
            Console.WriteLine("ToShortTimeString: " + timeExample.ToShortTimeString());
            Console.WriteLine("ToLongTimeString: " + timeExample.ToLongTimeString());

            Console.ReadKey();
        }
    }
}
