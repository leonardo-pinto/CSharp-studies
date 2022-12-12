using static System.Console;

namespace MethodsExtensionExample
{
    internal class Program
    {
        static void Main()
        {
            Product product = new Product()
            { 
                Cost = 100,
                DiscountPercentage = 10
            };

            WriteLine(product.GetDiscount());
            ReadKey();

        }
    }
}
