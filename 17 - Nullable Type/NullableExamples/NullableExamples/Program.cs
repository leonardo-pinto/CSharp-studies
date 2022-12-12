using static System.Console;

class Program
{
    static void Main()
    {
        Person person1 = new Person() { numberOfChildren = 1 };
        Person person2 = new Person() { numberOfChildren = null };
        // reference types as classes are nullable by default
        Person person3 = null;

        WriteLine("Number of childrens: " + person1.numberOfChildren);

        // use HasValue to check if property is null
        if (person2.numberOfChildren.HasValue)
        {
            // numberOfChildren is nullable
            // not possible to assign it to int value type
            // must use Value
            int value = person2.numberOfChildren.Value;
            WriteLine("Number of childrens: " + value);
        }

        ReadKey();
    }
}