using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerializationExample
{
    // add decorator to serialize class
    [Serializable]
    public class Country
    {
        public short CountryId { get; set; }
        public string CountryName { get; set; }
        public long Population { get; set; }
        public string Region { get; set; }

    }
    internal class Program
    {
        static void Main()
        {
            // Serialization

            //Country country = new Country() { CountryId = 1, CountryName = "Russia", Population = 10000, Region = "Eastern Europe" };

            //// create FileStream
            //string filePath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\russia.txt";
            //FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            //// create BinaryFormatter
            //BinaryFormatter binaryFormatter = new BinaryFormatter();
            //binaryFormatter.Serialize(fileStream, country);
            //fileStream.Close();

            //Console.WriteLine("File serialized");
            //Console.ReadKey();

            // Deserialization


            string filePath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\russia.txt";
            FileStream filestream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Country fileContent = (Country)binaryFormatter.Deserialize(filestream);

            Console.WriteLine(fileContent.CountryName);
            Console.WriteLine(fileContent.CountryId);
            Console.WriteLine(fileContent.Population);
            Console.WriteLine(fileContent.Region);

            Console.ReadKey();
        
        }
    }
}
