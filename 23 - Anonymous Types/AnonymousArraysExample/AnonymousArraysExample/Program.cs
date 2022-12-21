using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousArraysExample
{
    internal class Program
    {
        static void Main()
        {
            // create anonymous array / implicitly typed array
            var persons = new[]
            {
                new { PersonName = "Joseph", PersonAge = 40 },
                new { PersonName = "Richards", PersonAge = 55},
                // elements with other properties or types
                // are not allowed
                //new { PersonName = "Zé Urso" }
            };
        }
    }
}
