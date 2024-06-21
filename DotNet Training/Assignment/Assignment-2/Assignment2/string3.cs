using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class string3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the 1st word:");
            string word1 = Console.ReadLine();

            Console.WriteLine("Enter the 2nd word:");
            string word2 = Console.ReadLine();

            if (string.Equals(word1, word2, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The words are same.");
            }
            else
            {
                Console.WriteLine("The words are different.");
            }
            Console.ReadLine();
        }
    }
}
 
 
    

