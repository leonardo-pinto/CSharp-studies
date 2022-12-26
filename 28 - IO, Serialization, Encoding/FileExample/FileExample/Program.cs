using System;
using System.IO;

namespace FileExample
{
    internal class Program
    {
        static void Main()
        {

            string filePath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice";
            string fileName = "file_test.txt";
            string anotherFileName = "file_copy_test.txt";
            string moveFileName = "file_move_test.txt";

            string fullFilePath = $"{filePath}\\{fileName}";
            // Create method
            // create and opens the file
            // need to execute Close() method
            File.Create(fullFilePath).Close();
            Console.WriteLine($"{fileName} was created successfully");


            // Exists method
            Console.WriteLine("File exists? " + File.Exists(fullFilePath)); // true
            Console.WriteLine("File exists? " + File.Exists("abuble")); // false

            bool exists = File.Exists(fullFilePath);
            if (exists)
            {
                // Copy method
                // throws exception if anotherFileName already exists
                File.Copy(fullFilePath, $"{filePath}\\{anotherFileName}");
                Console.WriteLine($"Copied {fileName} to {anotherFileName}");


                // Move method
                File.Move($"{filePath}\\{anotherFileName}", $"{filePath}\\{moveFileName}");
                Console.WriteLine("File moved successfully");

                // Delete method
                File.Delete($"{filePath}\\{moveFileName}");
                Console.WriteLine("File deleted successfully");
            }
            else
            {
                Console.WriteLine("File not found");
            }

            Console.ReadKey();
        }
    }
}
