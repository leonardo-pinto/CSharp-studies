public class Product
{
    public string name;
    public int cost;
    public double tax;
    public static int totalProducts;
    public const string manufacturer = "Microsoft";
    public readonly string dateOfPurchase;

    public Product()
    {
        dateOfPurchase = System.DateTime.Now.ToShortDateString();
    }

    public void SetName(string value)
    {
        name = value;
    }

    public string GetName()
    {
        return name;
    }

    public void SetCost(int value)
    {
        cost = value;
    }

    public int GetCost()
    {
        return cost;
    }

    public void CalculateTax()
    {
        if (cost <= 1000)
        {
            tax = 0.125;
        } else
        {
            tax = 0.25;
        }
    }

    public double GetTax()
    {
        return tax;
    }

    public string GetDateOfPurchase()
    {
        return dateOfPurchase;
    }


   
}