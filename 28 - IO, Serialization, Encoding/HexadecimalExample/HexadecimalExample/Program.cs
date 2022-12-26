using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexadecimalExample
{
    internal class Program
    {
        static void Main()
        {
            int initNumber = 15649;

            string hexadecimalNumber = Convert.ToString(initNumber, 16);

            int decimalNumber = Convert.ToInt32(hexadecimalNumber, 16);

            Console.WriteLine(hexadecimalNumber);
            Console.WriteLine(decimalNumber);
            Console.ReadKey();
        }
    }
}
