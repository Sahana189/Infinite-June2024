using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_3
{
    class Assn5
    {
        static void Main()
        {
            Console.WriteLine("Enter a digit: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("{0} {0} {0} {0}", num);
            Console.WriteLine("{0}{0}{0}{0}", num);

            Console.WriteLine("{0} {0} {0} {0}", num);
            Console.WriteLine("{0}{0}{0}{0}", num);

            Console.ReadLine();
        }
    }

}
