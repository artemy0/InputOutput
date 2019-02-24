using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InputOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToFolder;
            bool continueTheCycle = true;

            Console.Write("Enter the path to the folder you want to work with: ");
            do
            {
                pathToFolder = Console.ReadLine();
                Console.WriteLine();

                DirectoryInfo directory = new DirectoryInfo(pathToFolder);
                if (directory.Exists)
                {
                    Console.WriteLine("Files in the folder:");
                    //displays all files located in the directory.
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        Console.WriteLine(file.Name);
                    }
                    continueTheCycle = false; //exit from the loop as the folder is found and all files contained in it are displayed.
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("Folder not found. Try again to enter the path to the folder you want to work: ");
                }
            } while (continueTheCycle);


            continueTheCycle = true;
            Console.Write("Enter the name of the file whose content you want to find out: ");
            do
            {
                string fileName = Console.ReadLine();
                Console.WriteLine();

                //use class Path to specify file path
                string pathToFile = Path.Combine(pathToFolder, fileName);
                if (File.Exists(pathToFile))
                {
                    using (StreamReader sr = new StreamReader(pathToFile, System.Text.Encoding.Default)) //System.Text.Encoding.Default used to ensure that the letters of the Russian alphabet are displayed correctly.
                    {
                        Console.WriteLine(sr.ReadToEnd());
                    }
                    continueTheCycle = false;
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("File not found. Try again to enter the name of the file whose content you want to find out: ");
                }
            } while (continueTheCycle);

            Console.ReadKey();
        }
    }
}
