public class Sample
{
    static void Main()
    {

        // reference variables
        // stored in the stack
        Customer c1, c2;

        // objects stored in the heap
        c1 = new Customer();
        c2 = new Customer();

        c1.customerName = "John Doe";

        System.Console.WriteLine(c1.customerName);
        System.Console.ReadKey();

    }
}