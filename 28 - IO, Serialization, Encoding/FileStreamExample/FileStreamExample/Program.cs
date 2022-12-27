using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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
        }
    }
}
