using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class basic1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first integer:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second integer:");
            int num2 = int.Parse(Console.ReadLine());

            int sum = num1 + num2;

            if (num1 == num2)
            {
                int result = 3 * sum;
                Console.WriteLine($"The integers are the same. Triple of their sum is: {result}");
            }
            else
            {
                Console.WriteLine($"Sum of the two integers is: {sum}");
            }
            Console.ReadLine();
        }
    }
}
