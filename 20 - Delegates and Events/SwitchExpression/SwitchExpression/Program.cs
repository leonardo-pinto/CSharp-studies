namespace SwitchExpression
{
    class Program
    {
        static void Main()
        {
            int operation = 2; // several cases
            string result;

            // switch operation
            result = operation switch
            {
                1 => "Customer",
                2 => "Employee",
                _ => "Not available"
            };

            System.Console.WriteLine(result);
            System.Console.ReadKey();

        }
    }
}
