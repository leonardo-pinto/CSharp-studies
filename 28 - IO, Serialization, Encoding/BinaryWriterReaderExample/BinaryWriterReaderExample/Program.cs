using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinaryWriterReaderExample
{
    internal class Program
    {
        static void Main()
        {
            short countryId = 1;
            string countrName = "Belarus";
            long population = 5505400;
            string region = "Eastern Europe";

            string filePath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\belarus.txt";
            FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            // writes information in binary system
            using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
            {
                binaryWriter.Write(countryId);
                binaryWriter.Write(population);
                binaryWriter.Write(region);
                binaryWriter.Write(countrName);
            }

            Console.WriteLine("belarus.txt was created");

            Console.ReadKey();
        }
    }
}
