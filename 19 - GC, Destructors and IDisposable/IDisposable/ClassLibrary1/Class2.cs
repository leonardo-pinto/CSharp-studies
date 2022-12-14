namespace Sample
{
    public class DisposableExample2 : System.IDisposable
    {
        // constructor
        public DisposableExample2()
        {
            System.Console.WriteLine("Constructor 2 executed");
        }

        // method
        public void MethodExample()
        {
            System.Console.WriteLine("MethodExample 2 executed");
        }

        // dispose
        public void Dispose()
        {
            System.Console.WriteLine("Dispose 2 executed");
        }
    }
}