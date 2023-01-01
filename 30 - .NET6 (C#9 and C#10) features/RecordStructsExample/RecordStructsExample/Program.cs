namespace record_structs_example
{
    // without readonly, all properties are by default read/write
    public readonly record struct Person(string? Name, int? Age);

    public record struct Employee(string? Name, int? Age);

    class Program
    {
        static void Main()
        {
            Person person1 = new("Joseph", 50);
            Person person2 = person1; // reference copy


            Employee employee1 = new("Dawkings", 29);
            Employee employee2 = employee1;
            employee1.Age = 35;
            // Structs are value type
            Console.WriteLine(employee1.ToString());
            Console.WriteLine(employee2.ToString());
            //Console.WriteLine(person1.ToString());
        }
    }
}