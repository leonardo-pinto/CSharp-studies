using ClassLibraryExample;

namespace MultipleDelegatesExample
{
    internal class Program
    {
        static void Main()
        {
            // create object of Sample class
            Sample sample = new Sample();

            // create delegate object
            MyDelegate myDelegate = sample.Add;

            myDelegate += sample.Multiply;

            myDelegate.Invoke(10, 20);

            System.Console.ReadKey();

        }
    }
}
