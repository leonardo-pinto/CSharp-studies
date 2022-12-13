namespace Sample
{
    public class DisposableExample : System.IDisposable
    {
        // constructor
        public DisposableExample()
        {
            System.Console.WriteLine("Constructor executed");
        }

        // method
        public void MethodExample()
        {
            System.Console.WriteLine("MethodExample executed");
        }

        // dispose
        public void Dispose()
        {
            System.Console.WriteLine("Dispose executed");
        }
    }
}