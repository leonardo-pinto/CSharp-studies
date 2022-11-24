using System.Runtime.CompilerServices;

public class Product
{
    private string name;
    private int cost;
    private double tax;
    public static int totalProducts;
    public const string manufacturer = "Microsoft";
    private readonly string dateOfPurchase;

    // constructor
    public Product()
    {
        dateOfPurchase = System.DateTime.Now.ToShortDateString();
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void SetCost(int cost)
    {
        this.cost = cost;
    }

    public int GetCost()
    {
        return cost;
    }

    public void CalculateTax(in double percentage = 12)
    {
        if (cost <= 1000)
        {
            tax = percentage/100;
        } else
        {
            tax = 25/100;
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

    // static methods
    // used to manipulate static fields
    public static void SetTotalProducts(int value)
    {
        totalProducts = value + 1;
    }

    public static int GetTotalProducts()
    {
        return totalProducts;
    }


   
}