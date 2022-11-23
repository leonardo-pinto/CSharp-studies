class Program
{
    static void Main()
    {
        Product product1;
        product1= new Product();
        Product.SetTotalProducts(Product.GetTotalProducts());

        product1.SetName("Wireless Keyboard");
        product1.SetCost(80);
        product1.CalculateTax();


        System.Console.WriteLine("Product: " + product1.GetName());
        System.Console.WriteLine("Cost: " + product1.GetCost());
        System.Console.WriteLine("Tax: " + product1.GetTax());
        System.Console.WriteLine("Date of purchase: " + product1.GetDateOfPurchase());
        System.Console.WriteLine("Total number of products: " + Product.GetTotalProducts());

        System.Console.ReadKey();


    }
}