using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC1
{
    class PROG3
    {
        static void Main()
        {
            int num1, num2, num3;

            
            num1 = 1; num2 = 2; num3 = 3;
            Console.WriteLine(FindLargest(num1, num2, num3)); 

            num1 = 1; num2 = 3; num3 = 2;
            Console.WriteLine(FindLargest(num1, num2, num3)); 

            num1 = 1; num2 = 1; num3 = 1;
            Console.WriteLine(FindLargest(num1, num2, num3)); 

            num1 = 1; num2 = 2; num3 = 2;
            Console.WriteLine(FindLargest(num1, num2, num3));

            Console.ReadLine();
        }

        static int FindLargest(int a, int b, int c)
        {
            if (a >= b && a >= c)
            {
                return a;
            }
            else if (b >= a && b >= c)
            {
                return b;
            }
            else
            {
                return c;
            }
        }
    }
}
