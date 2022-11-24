class Program
{
    static void Main()
    {
        Product product1, product2;
        product1= new Product();
        Product.SetTotalProducts(Product.GetTotalProducts());

        product1.SetName("Wireless Keyboard");
        product1.SetCost(80);
        product1.CalculateTax();

        product2 = new Product();
        Product.SetTotalProducts(Product.GetTotalProducts());
        product2.SetName("Microsoft Office 365");
        product2.SetCost(150);
        // example of named arguments
        // if one argument is named, all the others must also be named
        product2.CalculateTax(percentage: 6.5);


        System.Console.WriteLine("Product: " + product1.GetName());
        System.Console.WriteLine("Cost: " + product1.GetCost());
        System.Console.WriteLine("Tax: " + product1.GetTax());
        System.Console.WriteLine("Date of purchase: " + product1.GetDateOfPurchase());
        System.Console.WriteLine("-----------------------------------");
        System.Console.WriteLine("Product: " + product2.GetName());
        System.Console.WriteLine("Cost: " + product2.GetCost());
        System.Console.WriteLine("Tax: " + product2.GetTax());
        System.Console.WriteLine("Date of purchase: " + product2.GetDateOfPurchase());
        System.Console.WriteLine("-----------------------------------");
        System.Console.WriteLine("Total number of products: " + Product.GetTotalProducts());

        System.Console.ReadKey();


    }
}