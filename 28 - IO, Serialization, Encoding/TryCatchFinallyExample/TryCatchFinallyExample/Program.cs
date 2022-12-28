using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchFinallyExample
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter first number: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Enter second number: ");
                int b = int.Parse(Console.ReadLine());
                int c = a/b;
                // if b = 0, throw new DividedByZeroException
                Console.WriteLine("Result of division: " + c);
            }
            // catches this specific exception
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
