using ClassLibrary1;

namespace SingleCastDelegatesExample
{
    internal class Program
    {
        static void Main()
        {
            // create object of Sample class
            SampleClass sampleClass = new SampleClass();
            
            // create delegate object or delegate and add method reference
            MyDelegates myDelegate = new MyDelegates(sampleClass.Add);

            // invoke method using delegate
            System.Console.WriteLine(myDelegate.Invoke(30, 40));
            System.Console.ReadKey();
        }
    }
}
