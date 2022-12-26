using System;
using System.Collections.Generic;
using System.IO;

namespace DirectoryClassExample
{
    internal class Program
    {
        static void Main()
        {
            string directoryPath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\countries";

            // static class
            Directory.CreateDirectory(directoryPath);
            Console.WriteLine("countries directory is created");

            string indiaPath = directoryPath + "\\india";
            string russiaPath = directoryPath + "\\russia";
            string brazilPath = directoryPath + "\\brazil";

            Directory.CreateDirectory(indiaPath);
            Directory.CreateDirectory(russiaPath);
            Directory.CreateDirectory(brazilPath);
            Console.WriteLine("Subdirectories were created");


            string capitalsFilePath = directoryPath + "\\capitals.txt";
            string sportsFilePath = directoryPath + "\\sports.txt";
            string populationFilePath = directoryPath + "\\population.txt";
            File.Create(capitalsFilePath).Close();
            File.Create(sportsFilePath).Close();
            File.Create(populationFilePath).Close();
            Console.WriteLine("Files created successfully!");

            string worldFolderPath = "C:\\Users\\Leonardo\\Documents\\Projects\\CSharp-studies\\28 - IO, Serialization, Encoding\\practice\\world";
            // throws exception if it already exists
            Directory.Move(directoryPath, worldFolderPath);
            Console.WriteLine("Countries folder has been renamed to world");

            string[] filesList = Directory.GetFiles(worldFolderPath);
            foreach (string file in filesList)
            {
                Console.WriteLine(file);
            }

            string[] directories = Directory.GetDirectories(worldFolderPath);
            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
            }

            // Delete
            // true enables directory deletion containing files and directories
            Directory.Delete(worldFolderPath, true);

            Console.ReadKey();
        }

    }
}
