/// <summary>
/// This simple program will count the lines of code contained within a directory
/// </summary>


using System;
using System.Collections.Generic;
using System.IO;

namespace Code_Lines
{
    public class Program
    {
        static Dictionary<string, int> linesCount = new Dictionary<string, int>();
        static List<string> extensions = new List<string> { ".cs", ".java", ".py", ".c", ".cpp", ".js" };
        static Dictionary<string, string> languages = new Dictionary<string, string>();
        static Dictionary<string, int> fileCount = new Dictionary<string, int>();

        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                // TODO write a usage message
                System.Console.WriteLine("Display help menu.");
            }
            else
            {
                // Directory should be arg[0]
                // DirectoryInfo info = new DirectoryInfo(args[0]);
                PopulateDictionaries();
                string rootDir = args[0];
                VerifyDirExists(rootDir);
                ExpandDirectories(rootDir);
                PrintResults();
            }
        }

        static void VerifyDirExists(string directory)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);
            try
            {
                if (!dir.Exists)
                {
                    System.Console.WriteLine("Error:\n" + dir.ToString() + "\nwas not found.");
                    Environment.Exit(1);
                }
            }
            catch (DirectoryNotFoundException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        static void ExpandDirectories(string directory)
        {
            foreach (string dir in Directory.GetDirectories(directory))
            {
                // System.Console.WriteLine(dir);
                foreach (string file in Directory.GetFiles(dir))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (extensions.Contains(fileInfo.Extension))
                    {
                        // TODO write function to read this file line by line and then adding it to dict
                        linesCount[fileInfo.Extension] += GetLineCount(file);
                        fileCount[fileInfo.Extension]++;
                    }

                }
                ExpandDirectories(dir);
            }
        }

        static void PopulateDictionaries()
        {
            foreach (string ext in extensions)
            {
                linesCount.Add(ext, 0);
                languages.Add(ext, null);
                fileCount.Add(ext, 0);
            }
            languages[".cs"] = "C#";
            languages[".java"] = "Java";
            languages[".py"] = "Python";
            languages[".c"] = "C";
            languages[".cpp"] = "C++";
            languages[".js"] = "JavaScript";
        }

        static int GetLineCount(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int count = 0;
            try
            {
                while (!sr.EndOfStream)
                {
                    sr.ReadLine();
                    count++;
                }
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
            }
            return count;
        }

        static void PrintResults()
        {
            System.Console.WriteLine("Analysis:");
            foreach (KeyValuePair<string, int> entry in linesCount)
            {
                System.Console.WriteLine("Total lines of {0, -20} {1, -7} {2}.",
                 languages[entry.Key] + ":",
                 entry.Value,
                 "in " + fileCount[entry.Key] + " files");
            }
        }
    }
}
