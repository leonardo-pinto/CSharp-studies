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
            string countryName = "Belarus";
            long population = 5505400;
            string region = "Eastern Europe";

            string filePath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\belarus.txt";
            FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            // writes information in binary system
            // BinaryWriter
            using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
            {
                binaryWriter.Write(countryId);
                binaryWriter.Write(countryName);
                binaryWriter.Write(population);
                binaryWriter.Write(region);
            }

            Console.WriteLine("belarus.txt was created");
            FileStream filestream2 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            // BinaryReader
            using (BinaryReader binaryReader = new BinaryReader(filestream2))
            {
                int countryIdFromFile = binaryReader.ReadInt16();
                string countryNameFromFile = binaryReader.ReadString();
                long populationFromFile = binaryReader.ReadInt64();
                string countryRegionFromFile = binaryReader.ReadString();


                Console.WriteLine("Country id: " + countryIdFromFile);
                Console.WriteLine("Country name: " + countryNameFromFile);
                Console.WriteLine("Country population: " + populationFromFile);
                Console.WriteLine("Country region: " + countryRegionFromFile);
            }

            Console.ReadKey();
        }
    }
}
