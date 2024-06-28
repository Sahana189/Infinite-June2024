using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Lettercount
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string inputString = Console.ReadLine();

            Console.WriteLine("Enter the letter to be counted:");
            char letterToCount = Console.ReadKey().KeyChar;
            Console.WriteLine();

            int count = 0;
            foreach (char c in inputString)
            {
                if (c == letterToCount)
                {
                    count++;
                }
            }

            Console.WriteLine($"The letter '{letterToCount}' appears {count} times in the string \"{inputString}\".");
            Console.ReadLine();
        }
    }
}
