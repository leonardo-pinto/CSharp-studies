using recordsExample;

namespace recordsExample
{
    public record Person(string Name, int Age, Address PersonalAddress)
    {
        public string? Gender { get; set; }
    }

    public record Address(string City, string Country);


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
        Person person1 = new("Joseph Richards", 50, new Address("Jundiai", "Brazil"))
        {
            Gender = "Elu"
        };
        Person person2 = new("Joseph Richards", 50, new Address("Jundiai", "Brazil"))
        {
            Gender = "Elu"
        };
        Console.WriteLine($"{person1.Name}, {person1.Age}, {person1.PersonalAddress.City}, {person1.PersonalAddress.Country}");

        // Specific for records
        // In classes, it compares the reference of the object in the heap
        Console.WriteLine(person1 == person2);
        Console.WriteLine(person1.Equals(person2));
    }
}