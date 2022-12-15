using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncExample
{
    internal class Program
    {
        static void Main()
        {
            Publisher publisher = new Publisher();

            publisher.MyEvent += (a, b) => a + b;

            System.Console.WriteLine(publisher.RaiseEvent(1, 1));
            System.Console.ReadKey();
        }
    }
}
