using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamWriterReaderExample
{
    internal class Program
    {
        static void Main()
        {
            string filePath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\europe.txt";
           
            // using construct is recommended
            // file is closed after closing brackets
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine("Halo");

                streamWriter.WriteLine("how are you?");

            };
        }
    }
}
