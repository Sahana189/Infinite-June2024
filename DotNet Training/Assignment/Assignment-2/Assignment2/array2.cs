using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class array2
    {
        static void Main()
        {
          
            int[] marks = new int[10];

       
            Console.WriteLine("Enter ten marks:");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write($"Enter mark {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }

            
            int total = CalculateTotal(marks);
            Console.WriteLine($"Total marks: {total}");

            
            double average = CalculateAverage(marks);
            Console.WriteLine($"Average marks: {average}");

            
            int min = FindMinimum(marks);
            Console.WriteLine($"Minimum marks: {min}");

         
            int max = FindMaximum(marks);
            Console.WriteLine($"Maximum marks: {max}");

            
            Console.WriteLine("Marks in ascending order:");
            DisplayAscendingOrder(marks);

           
            Console.WriteLine("Marks in descending order:");
            DisplayDescendingOrder(marks);

            Console.ReadLine();
        }

        static int CalculateTotal(int[] marks)
        {
            int sum = 0;
            foreach (int mark in marks)
            {
                sum += mark;
            }
            return sum;
        }

        static double CalculateAverage(int[] marks)
        {
            if (marks.Length == 0)
                return 0;

            int total = CalculateTotal(marks);
            return (double)total / marks.Length;
        }

        static int FindMinimum(int[] marks)
        {
            if (marks.Length == 0)
                throw new ArgumentException("Array must not be empty.");

            int min = marks[0];
            for (int i = 1; i < marks.Length; i++)
            {
                if (marks[i] < min)
                    min = marks[i];
            }
            return min;
        }

        static int FindMaximum(int[] marks)
        {
            if (marks.Length == 0)
                throw new ArgumentException("Array must not be empty.");

            int max = marks[0];
            for (int i = 1; i < marks.Length; i++)
            {
                if (marks[i] > max)
                    max = marks[i];
            }
            return max;
        }

        static void DisplayAscendingOrder(int[] marks)
        {
            Array.Sort(marks);
            foreach (int mark in marks)
            {
                Console.WriteLine(mark);
            }
        }

        static void DisplayDescendingOrder(int[] marks)
        {
            Array.Sort(marks);
            Array.Reverse(marks);
            foreach (int mark in marks)
            {
                Console.WriteLine(mark);
            }
        }
    }
}
