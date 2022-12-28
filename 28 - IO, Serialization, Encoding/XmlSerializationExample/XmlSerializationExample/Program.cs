using System;
using System.IO;
using System.Xml.Serialization;


namespace XmlSerializationExample
{
    [Serializable]
    public class Manager
    {
        public string Name { get; set; }
        public int Age { get; set; }
    
    }

    internal class Program
    {
        static void Main()
        {
            // Serialization
            //Manager manager = new Manager() { Name = "Joseph", Age = 63 };

            //string filePath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\manager.txt";

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Manager));

            //using (StreamWriter streamWriter = new StreamWriter(filePath))
            //{
            //    xmlSerializer.Serialize(streamWriter, manager);
            //    Console.WriteLine("File serialized");
            //}

            //Console.ReadKey();


            // Deserialization

            string filePath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\manager.txt";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Manager));

            using (StreamReader streamWriter = new StreamReader(filePath))
            {
                Manager fileContent = xmlSerializer.Deserialize(streamWriter) as Manager;
                Console.WriteLine(fileContent.Name);
                Console.WriteLine(fileContent.Age);
            }

            Console.ReadKey();
        }
    }
}
