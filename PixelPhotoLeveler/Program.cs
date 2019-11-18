using System;
using System.IO;

namespace PixelPhotoLeveler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the path to the folder you would like leveled?");
            string parent = Console.ReadLine();
            Console.WriteLine("Moving all files into parent directory...");

            LevelFolder(parent, parent);

            Console.WriteLine("Done");
        }

        public static void LevelFolder(string parent, string subDir = "")
        {
            string[] files = Directory.GetFiles(subDir);
            string[] subDirectories;

            if (subDir == "")
            {
                subDirectories = Directory.GetDirectories(parent);
            } else
            {
                subDirectories = Directory.GetDirectories(subDir);
            }

            // recursively running on each subfolder to bring all files up
            foreach (string dir in subDirectories)
            {
                LevelFolder(parent, dir);
            }

            if (subDir != "")
            {
                // move each file into parent directory
                foreach (string _file in files)
                {
                    string filename = _file.Replace($"{subDir}\\", "");
                    File.Move(_file, $"{parent}\\{filename}");
                    Console.WriteLine($"Moved file - {filename}");
                }

                Directory.Delete(subDir);
                Console.WriteLine($"Deleted folder - {Path.GetFileName(subDir)}");
            }
        }
    }
}
