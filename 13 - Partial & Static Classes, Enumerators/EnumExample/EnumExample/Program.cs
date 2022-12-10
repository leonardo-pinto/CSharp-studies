using static System.Console;
class Program
{
    static void Main()
    {
        // create object of Person class
        Person person= new Person();
        person.PersonName = "John Doe";
        person.AgeGroup = AgeGroupEnumeration.Teenager;

        WriteLine(person.AgeGroup);
        ReadKey();


    }
}