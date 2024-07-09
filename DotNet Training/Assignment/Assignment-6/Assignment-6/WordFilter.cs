using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class WordFilter
    {
        static void Main()
        {
            Console.WriteLine("Enter a list of words separated by spaces:");
            string input = Console.ReadLine();


            string[] wordArray = input.Split(' ');


            List<string> words = wordArray.ToList();


            var result = words.Where(word => word.StartsWith("a", StringComparison.OrdinalIgnoreCase) && word.EndsWith("m", StringComparison.OrdinalIgnoreCase));


            Console.WriteLine("Words starting with 'a' and ending with 'm':");
            foreach (var word in result)
            {
                Console.WriteLine(word);
                Console.ReadKey();
            }
        }
    }
}
    

