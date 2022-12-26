using System;
using System.Collections.Generic;
using System.IO;

namespace FIleInfoExample
{
    internal class Program
    {
        static void Main()
        {
            string filePath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\japan.txt";
            string filePathToCopy = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\japan_copy.txt";
            string filePathMove = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\japan_move.txt";

            // file info is not static
            FileInfo fileInfo = new FileInfo(filePath);
            // create and close the file
            fileInfo.Create().Close();

            Console.WriteLine(fileInfo.Name + " created");

            // CopyTo method
            // returns a new instance of the FileInfo class
            // any instance refers to a specific file
            // throws exception if it already exists
            FileInfo copiedFileInfo = fileInfo.CopyTo(filePathToCopy);

            Console.WriteLine(copiedFileInfo.Name + " created");

            // MoveTo method
            copiedFileInfo.MoveTo(filePathMove);
            Console.WriteLine(copiedFileInfo.Name + " moved");

            copiedFileInfo.Delete();
            Console.WriteLine(copiedFileInfo.Name + " deleted");

            Console.ReadKey();
        
        }
    }
}
