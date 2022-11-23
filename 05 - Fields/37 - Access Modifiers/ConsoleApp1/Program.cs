class Sample
{
    static void Main()
    {

    }
}


// child class at another assembly
public class InternationalProduct : Product
{
    public void Method1()
    {
        id = 5;
        name = "Dell Notebook";
        price = 100;
        quantity = 100;
        manufacturer = "Microsoft";
        discount = 2;
    }
}


// another class at another assembly
public class AnotherClass2
{
    public void Method2() 
    {
        Product product = new Product();
        product.id = 10;
        product.name = "Dell Notebook";
        product.price = 100;
        product.quantity = 100;
        product.manufacturer = "Microsoft";
        product.discount = 0;
    }
}

