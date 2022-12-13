using Sample;
class Program
{
    static void Main()
    {
        // create object using "using structure"
        using (DisposableExample sample = new DisposableExample())
        {
            sample.MethodExample();
        } // dispose is executed after end of using block

        System.Console.WriteLine("Execution after using block");
        System.Console.ReadKey();
    }
}