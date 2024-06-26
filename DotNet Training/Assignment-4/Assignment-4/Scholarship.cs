using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Scholarship
    {
        public void Merit(int marks, decimal fees)
        {
            decimal scholarshipAmount = 0;

            if (marks >= 70 && marks <= 80)
            {
                scholarshipAmount = fees * 0.20m;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = fees * 0.30m;
            }
            else if (marks > 90)
            {
                scholarshipAmount = fees * 0.50m;
            }

            Console.WriteLine($"The scholarship amount is: {scholarshipAmount}");
        }

        static void Main(string[] args)
        {
            Scholarship scholarship = new Scholarship();

            Console.WriteLine("Enter marks:");
            int marks = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter fees:");
            decimal fees = decimal.Parse(Console.ReadLine());

            scholarship.Merit(marks, fees);
            Console.ReadLine();
        }
    }
}
