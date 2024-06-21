using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class array1
    {
        static void Main()
        {
            
            int[] numbers = { 5, 12, 3, 8, 15, 9 };

            
            double average = CalculateAverage(numbers);
            Console.WriteLine($"Average value of array elements: {average}");

           
            int min = FindMinimum(numbers);
            int max = FindMaximum(numbers);
            Console.WriteLine($"Minimum value in the array: {min}");
            Console.WriteLine($"Maximum value in the array: {max}");

            Console.ReadLine();
        }

        static double CalculateAverage(int[] arr)
        {
            if (arr.Length == 0)
                return 0;

            int sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }

            return (double)sum / arr.Length;
        }

        static int FindMinimum(int[] arr)
        {
            if (arr.Length == 0)
                throw new ArgumentException("Array must not be empty.");

            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }

        static int FindMaximum(int[] arr)
        {
            if (arr.Length == 0)
                throw new ArgumentException("Array must not be empty.");

            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }
    }

}

