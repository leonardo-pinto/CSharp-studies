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
        WriteLine();

        // use HasValue to check if property is null
        // verbose syntax
        //if (person2.numberOfChildren.HasValue)
        //{
        //    // numberOfChildren is nullable
        //    // not possible to assign it to int value type
        //    // must use Value
        //    int value = person2.numberOfChildren.Value;
        //    WriteLine("Number of childrens: " + value);
        //}

        // ternary operator
        WriteLine("Example using ternary operator");
        WriteLine(person1.numberOfChildren.HasValue ? person1.numberOfChildren.Value : 0);
        WriteLine(person2.numberOfChildren.HasValue ? person2.numberOfChildren.Value : 0);

        // coalescing operator
        WriteLine("Example using coalescing operator");
        // alternative argument type must be the same field type (int)
        WriteLine(person1.numberOfChildren ?? 0);
        WriteLine(person2.numberOfChildren ?? 0);
        ReadKey();
    }
}