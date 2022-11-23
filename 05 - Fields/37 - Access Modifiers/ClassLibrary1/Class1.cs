public class Product
{
    // fields
    public int id;
    private string name;
    protected int price;
    private protected int quantity;
    internal string manufacturer;
    protected internal int discount;
}

// child class at the same assembly
public class DomesticProduct: Product
{
    public void Method1()
    {
        id = 1;
        name = "Dell Notebook";
        price = 100;
        quantity = 100;
        manufacturer = "Microsoft";
        discount = 5;
    }
}

// another class at the same assembly
public class AnotherClass
{
    public void Method()
    {
        Product product1;
        product1 = new Product();
        product1.id = 1;
        product1.name = "Dell Notebook";
        product1.price = 100;
        product1.quantity = 100;
        product1.manufacturer = "Microsoft";
        product1.discount = 3;
    }
}
