using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctalExample
{
    internal class Program
    {
        static void Main()
        {
            int decimalNumber = 289;

            // convert decimal to octal number system
            string octalNumber = Convert.ToString(decimalNumber, 8);

            // convert octal number to decimal number
            int convertedNumber = Convert.ToInt32(octalNumber, 8);

            Console.WriteLine(octalNumber);

            Console.WriteLine(convertedNumber);

            Console.ReadKey();
        }
    }
}
