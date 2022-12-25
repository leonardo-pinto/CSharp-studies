using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAdditionExample
{
    internal class Program
    {
        static void Main()
        {
            DateTime dt = DateTime.Parse("2042-10-10");
            DateTime addedDate = dt.AddDays(5);

            // AddMinutes
            // AddSeconds, Milliseconds, etc
            // Add negative values to subtract;
            Console.WriteLine(addedDate.ToString());   
            Console.ReadKey();
        }
    }
}
