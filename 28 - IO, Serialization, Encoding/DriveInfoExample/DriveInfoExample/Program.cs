using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DriveInfoExample
{
    internal class Program
    {
        static void Main()
        {
            DriveInfo driveInfo = new DriveInfo("c:");

            Console.WriteLine("Name: " + driveInfo.Name);
            Console.WriteLine("DriveType: " + driveInfo.DriveType);
            Console.WriteLine("Volume label: " + driveInfo.VolumeLabel);
            Console.WriteLine("Root Directory: " + driveInfo.RootDirectory);
            // data in Gb
            Console.WriteLine("Total size: " + (driveInfo.TotalSize / 1024 / 1024 /1024) + "gb");
            Console.WriteLine("Free space: " + (driveInfo.AvailableFreeSpace / 1024 / 1024 / 1024) + "gb");


            Console.ReadKey();
        }
    }
}
