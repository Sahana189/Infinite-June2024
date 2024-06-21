using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC1
{
    class PROG4
    {
        static void Main()
        {
            Console.Write("Enter the number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Multiplication table of {number}:");
            for (int i = 0; i <= 10; i++)
            {
                int result = number * i;
                Console.WriteLine($"{number} * {i} = {result}");

                Console.ReadLine();
            }
        }
    }
}

