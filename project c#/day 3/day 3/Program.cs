using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            
                int num1, num2, temp;

                Console.WriteLine("Enter the first number: ");
                num1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the second number: ");
                num2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nBefore swapping:" + num1 + " " + num2);
                Console.WriteLine("First number: " + num1);
                Console.WriteLine("Second number: " + num2);
                temp = num1;
                num1 = num2;
                num2 = temp;

                Console.WriteLine("\nAfter swapping:" + num1 + " " + num2);
                Console.WriteLine("First number: " + num1);
                Console.WriteLine("Second number: " + num2);

                Console.ReadLine();
            

        }
    }
}
