using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace FileStreamExample
{
    internal class Program
    {
        static void Main()
        {
            string filePath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\cat.txt";

            // both syntax are the same, since File.Create returns a FileStream
            //FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);       
            FileStream fileStream = File.Create(filePath);

            // create content
            string content = "Cat is one of the domestic animals";

            // FileStream uses byte
            byte[] byteContent = Encoding.ASCII.GetBytes(content);

            fileStream.Write(byteContent, 0, byteContent.Length);

            string content2 = "more content";
            byte[] byteContent2 = Encoding.ASCII.GetBytes(content2);

            fileStream.Write(byteContent2, 0, byteContent2.Length);

            Console.WriteLine("cat.txt was created");
            fileStream.Close();

            Console.ReadKey();
        }
    }
}
