class Sample
{
    static void Main()
    {
        Product product1, product2, product3;

        // create objects
        product1 = new Product();
        // const field is common to all objects, and can not be changed
        Product.storeName = "dale";

        Product.productAmount++;
        // static field is commont ao all objects, but can be changed
        product2 = new Product();
        Product.productAmount++;
        product3 = new Product();
        Product.productAmount++;

        // initialize fields
        product1.id = 1;
        product2.id = 2;
        product3.id = 3;

        // readonly field can not be assigned
        product1.dateOfPurchase = "fdfdfd";
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

