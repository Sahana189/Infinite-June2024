using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class string1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();

            int length = word.Length;
            Console.WriteLine($"The length of the word entered is '{word}' is: {length}");
            Console.ReadLine();
        }
    }
}
