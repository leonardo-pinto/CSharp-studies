
namespace MethodsExtensionExample
{
    // static class for extension method
    public static class ProductExtensions
    {
        // static method for Product class
        public static double GetDiscount(this Product product)
        {
            return product.Cost - (product.Cost * product.DiscountPercentage/100);
        }
    }
}
