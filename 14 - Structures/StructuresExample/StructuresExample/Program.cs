using static System.Console;

class Program
{
    static void Main()
    {
        // create structure instance
        // new keyword is not creating an object
        // only initializes structure fields
        // using parameless constructor
        Category category = new Category(1, 2);
     

        WriteLine("Category ID: " + category.CategoryId);
        WriteLine("Code number: " + category.CodeNumber);
        ReadKey();
    }
}