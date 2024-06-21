using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class array3
    {
        static void Main()
        {
           
            int[] originalArray = { 1, 2, 3, 4, 5 };

         
            int[] newArray = new int[originalArray.Length];

            
            for (int i = 0; i < originalArray.Length; i++)
            {
                newArray[i] = originalArray[i];
            }

            
            Console.WriteLine("Original Array:");
            PrintArray(originalArray);

           
            Console.WriteLine("\nCopied Array:");
            PrintArray(newArray);

            Console.ReadLine();
        }

        
        static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

    }
}
