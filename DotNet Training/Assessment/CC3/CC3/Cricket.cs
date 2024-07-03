using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC3
{
    internal class Cricket
    {
        public void Pointscalculation(int no_of_matches)
        {
            int[] scores = new int[no_of_matches];
            int sum = 0;

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Enter score for match {i + 1}: ");
                scores[i] = Convert.ToInt32(Console.ReadLine());
                sum += scores[i];
            }

            double average = (double)sum / no_of_matches;

            Console.WriteLine($"Sum of scores: {sum}");
            Console.WriteLine($"Average score: {average:F2}");
            Console.ReadLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of matches: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Cricket cricket = new Cricket();
            cricket.Pointscalculation(n);
        }
    }
}

