using System;
using System.IO;

namespace PixelPhotoLeveler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the path to the folder you would like leveled?");
            Console.WriteLine("e.g.: C:\\Users\\<Username>\\Pictures");
            string parent = Console.ReadLine();
            Console.WriteLine("Moving all files into parent directory...");

            LevelFolder(parent);

            Console.WriteLine("Done");
        }

        public static void LevelFolder(string parent, string subDir = "")
        {
            string[] files;
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
                files = Directory.GetFiles(subDir);
                
                // move each file into parent directory
                foreach (string _file in files)
                {
                    string filename = Path.GetFileNameWithoutExtension(_file);
                    string extension = Path.GetExtension(_file);
                    int i;
                    string numberOfCopy = "";

                    // if there is already a file with the same name, move the file with "(i)" added at the end
                    if (File.Exists($"{parent}\\{filename}{extension}"))
                    {
                        i = 1;
                        while (File.Exists($"{parent}\\{filename}({i}){extension}"))
                        {
                            i++;
                        }

                        numberOfCopy = $"({i})";
                    }

                    File.Move(_file, $"{parent}\\{filename}{numberOfCopy}{extension}");
                    Console.WriteLine($"Moved file - {filename}");
                }

                Directory.Delete(subDir);
                Console.WriteLine($"Deleted folder - {Path.GetFileName(subDir)}");
            }
        }
    }
}
