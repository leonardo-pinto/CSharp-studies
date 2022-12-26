using System;
using System.Collections.Generic;
using System.IO;

namespace DirectoryInfoExample
{
    internal class Program
    {
        static void Main()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\countries");

            // Create directory
            directoryInfo.Create();
            Console.WriteLine("Countries folder created");

            directoryInfo.CreateSubdirectory("india");
            directoryInfo.CreateSubdirectory("russia");

            new FileInfo(directoryInfo.FullName + "\\capitals.txt").Create();

            Console.ReadKey();
        }
    }
}
