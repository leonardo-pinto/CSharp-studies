using static System.Console;

class Program
{
    static void Main()
    {
        // create structure instance
        // new keyword is not creating an object
        // only initializes structure fields
        // using parameless constructor
        Category category = new Category()
        {
            CategoryId = 1,
        };

        WriteLine("Category ID: " + category.CategoryId);
        ReadKey();
    }
}