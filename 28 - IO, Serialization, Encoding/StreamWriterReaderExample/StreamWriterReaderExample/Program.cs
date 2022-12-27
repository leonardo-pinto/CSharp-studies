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
            }

            // Reader

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                // to read full file
                //string fileContent = streamReader.ReadToEnd();
                //Console.WriteLine("File content");
                //Console.WriteLine(fileContent);

                // to read file part by part (10 characters)
                char[] buffer = new char[10];
                streamReader.Read(buffer, 0, buffer.Length);
                Console.WriteLine(new string(buffer));
            }
            // use a do-while loop 

            Console.ReadKey();
        }
    }
}
