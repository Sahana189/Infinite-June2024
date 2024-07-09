using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
class NumberSquares
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers separated by spaces:");
        string input = Console.ReadLine();


        string[] numberStrings = input.Split(' ');


        List<int> numbers = new List<int>();
        foreach (string numString in numberStrings)
        {
            if (int.TryParse(numString, out int num))
            {
                numbers.Add(num);
            }
            else
            {
                Console.WriteLine($"Invalid input: {numString}. Skipping...");
            }
        }


        var result = numbers.Select(n => n * n).Where(square => square > 20);

        Console.WriteLine("Numbers and their squares greater than 20:");
        foreach (var square in result)
        {
            Console.WriteLine(square);
            Console.ReadKey();
        }
    }
} }

