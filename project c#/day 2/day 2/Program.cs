using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_2
{
    class Program
    {
        /*   static void Main(string[] args)
           {
               Console.WriteLine("Enter the first integer:");
               int num1 = int.Parse(Console.ReadLine());
               Console.WriteLine("Enter the second integer:");
               int num2 = int.Parse(Console.ReadLine());
               if (num1 == num2)
               {
                   Console.WriteLine("The integers are equal.");
               }
               else
               {
                   Console.WriteLine("The integers are not equal.");
               }*/

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number > 0)
            {
                Console.WriteLine("The number is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine("The number is negative.");
            }
            else
            {
                Console.WriteLine("The number is zero.");
            }
        
        Console.ReadLine();
        }
    }
}
