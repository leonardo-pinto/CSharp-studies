using recordsExample;
using System.Net.Sockets;

namespace recordsExample
{
    public record Person(string Name, int Age, Address PersonalAddress);
    public record Address(string City);


}


//class Person
//{
//    public string Name { get; init; }
//    public int Age { get; init; }

//    public Person(string name, int age)
//    {
//        this.Name = name;
//        this.Age = age;
//    }
//}

class Program
{
    static void Main()
    {
        Person person = new("Joseph Richards", 50, new Address("Jundiai"));
        Console.WriteLine($" {person.Name}, {person.Age}, {person.PersonalAddress.City}");
    }
}