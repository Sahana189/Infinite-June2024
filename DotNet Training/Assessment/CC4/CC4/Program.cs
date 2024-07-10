using System;
using System.IO;

namespace CC4
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\batch 2024 June\\DotNet Training\\Assessment\\CC4\\Sahana.txt";
            string textToAppend = "Welcome to Infinite Computer Solutions";

            AppendTextToFile(filePath, textToAppend);

            Console.WriteLine("Text has Succesfully appended to the file.");
            Console.ReadLine();
        }

        static void AppendTextToFile(string filePath, string text)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(text);
            }
        }
    }
}