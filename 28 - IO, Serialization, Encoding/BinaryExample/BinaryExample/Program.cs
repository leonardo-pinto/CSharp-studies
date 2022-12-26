using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryExample
{
    internal class Program
    {
        static void Main()
        {
            // numbers are represented in decimal system
            int decimalNumber = 13;

            // binary number is represented as string
            string binaryNumber = Convert.ToString(decimalNumber, 2);

            Console.WriteLine(binaryNumber);

            // convert to decimal number
            Console.WriteLine(Convert.ToInt32(binaryNumber, 2));

            Console.ReadKey();
        }
    }
}
