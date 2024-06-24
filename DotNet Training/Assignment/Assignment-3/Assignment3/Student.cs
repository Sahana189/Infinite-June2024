using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    using System;
    class Student
    {
        private int rollNo;
        private string name;
        private string studentClass;
        private int semester;
        private string branch;
        private int[] marks = new int[5];

        public Student(int rollNo, string name, string studentClass, int semester, string branch)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.studentClass = studentClass;
            this.semester = semester;
            this.branch = branch;
        }

        public void GetMarks()
        {
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine($"Enter marks for subject {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            int total = 0;
            bool isFailed = false;

            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] < 35)
                {
                    Console.WriteLine("Result: Failed");
                    isFailed = true;
                    break;
                }
                total += marks[i];
            }

            if (!isFailed)
            {
                double average = total / (double)marks.Length;
                if (average < 50)
                {
                    Console.WriteLine("Result: Failed");
                }
                else
                {
                    Console.WriteLine("Result: Passed");
                }
            }
        }

        public void DisplayData()
        {
            Console.WriteLine($"Roll No: {rollNo}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Class: {studentClass}");
            Console.WriteLine($"Semester: {semester}");
            Console.WriteLine($"Branch: {branch}");
            Console.WriteLine("Marks: " + string.Join(", ", marks));
        }



        public static void Main(string[] args)
        {
            Student student = new Student(105, "Rose", "10th Grade", 2, "Maths");
            student.GetMarks();
            student.DisplayData();
            student.DisplayResult();
            Console.ReadLine();
        }
    }
    }


