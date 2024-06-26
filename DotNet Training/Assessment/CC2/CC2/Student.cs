using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC2
{
   abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }


        public abstract bool IsPassed(double grade);
    }


    class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            if (grade > 70.0)
                return true;
            else
                return false;
        }
    }


    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            if (grade > 80.0)
                return true;
            else
                return false;
        }
    }

    class Question1

    {
        static void Main(string[] args)
        {
            Undergraduate undergraduate = new Undergraduate();
            undergraduate.Name = "Dhruv";
            undergraduate.StudentId = 87696;
            undergraduate.Grade = 75.5;


            Console.WriteLine("Undergraduate Result:");
            Console.WriteLine("Name: " + undergraduate.Name);
            Console.WriteLine("Student ID: " + undergraduate.StudentId);
            Console.WriteLine("Grade: " + undergraduate.Grade);
            Console.WriteLine("Passed: " + undergraduate.IsPassed(undergraduate.Grade));
            Console.WriteLine();


            Graduate graduate = new Graduate();
            graduate.Name = "Sahana";
            graduate.StudentId = 7845362;
            graduate.Grade = 89.5;


            Console.WriteLine("Graduate Result:");
            Console.WriteLine("Name: " + graduate.Name);
            Console.WriteLine("Student ID: " + graduate.StudentId);
            Console.WriteLine("Grade: " + graduate.Grade);
            Console.WriteLine("Passed: " + graduate.IsPassed(graduate.Grade));

            Console.ReadLine();
        }
    }
}

