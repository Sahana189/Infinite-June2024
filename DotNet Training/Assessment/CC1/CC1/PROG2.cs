using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC1
{
    class PROG2
    {
        static void Main()
        {
            string input1 = "abcd";
            string result1 = ExchangeFirstAndLast(input1);
            Console.WriteLine(result1);

            string input2 = "a";
            string result2 = ExchangeFirstAndLast(input2);
            Console.WriteLine(result2); 

            string input3 = "xy";
            string result3 = ExchangeFirstAndLast(input3);
            Console.WriteLine(result3);

            Console.ReadLine();
        }

        static string ExchangeFirstAndLast(string str)
        {
            if (str.Length <= 1)
            {
                return str; 
            }

            char[] chars = str.ToCharArray();

            
            char temp = chars[0];
            chars[0] = chars[str.Length - 1];
            chars[str.Length - 1] = temp;

            return new string(chars);
        }
    }
}
  

        
