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

            Console.ReadKey();
        }
    }
}
