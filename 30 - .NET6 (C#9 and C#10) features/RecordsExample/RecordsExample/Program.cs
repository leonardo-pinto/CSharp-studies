using recordsExample;

namespace recordsExample
{
    public record Person(string Name, int Age, Address PersonalAddress)
    {
        public string? Gender { get; set; }
        public string? Name { get; set; }
    }

    public record Address(string City) 
    {
        public string? Country { get; set; }
    }


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
        Person person1 = new("Joseph Richards", 50, new Address("Jundiai"){ Country = "Brazil" })
        {
            Gender = "Elu", Name = "Joseph Richards"
        };
        Person person2 = person1; // reference copy

        // Shallow copy - independent object
        // However, if the field is a reference type
        // it works as a reference copy
        Person person3 = person1 with { }; // can overwritte by add values in the brackets

        Console.WriteLine($"Person1: {person1.Name}, {person1.Age}, {person1.PersonalAddress.City}, {person1.PersonalAddress.Country}");
        Console.WriteLine($"Person2: {person2.Name}, {person2.Age}, {person2.PersonalAddress.City}, {person2.PersonalAddress.Country}");
        Console.WriteLine($"Person3: {person3.Name}, {person3.Age}, {person3.PersonalAddress.City}, {person3.PersonalAddress.Country}");
        

        // Dont affect person3, since it is a shallow copy
        person1.Name = "John Doe";

        // Affects person3, since it is a reference type, therefore acts as a reference copy
        person1.PersonalAddress.Country = "Hawai";

        //Person person2 = new("Joseph Richards", 50, new Address("Jundiai", "Brazil"))
        //{
        //    Gender = "Elu"
        //};

        //person1.Name = "Another name";
        Console.WriteLine($"Person1: {person1.Name}, {person1.Age}, {person1.PersonalAddress.City}, {person1.PersonalAddress.Country}");
        Console.WriteLine($"Person2: {person2.Name}, {person2.Age}, {person2.PersonalAddress.City}, {person2.PersonalAddress.Country}");
        Console.WriteLine($"Person3: {person3.Name}, {person3.Age}, {person3.PersonalAddress.City}, {person3.PersonalAddress.Country}");

        // Specific for records
        // In classes, it compares the reference of the object in the heap
        //Console.WriteLine(person1 == person2);
        //Console.WriteLine(person1.Equals(person2));
    }
}