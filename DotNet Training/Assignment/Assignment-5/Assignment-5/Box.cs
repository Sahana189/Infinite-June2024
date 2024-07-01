using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }


        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }


        public static Box Add(Box box1, Box box2)
        {
            double length = box1.Length + box2.Length;
            double breadth = box1.Breadth + box2.Breadth;
            return new Box(length, breadth);
        }


        public void Display()
        {
            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
        }
    }

    class Box1_2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter dimensions for Box 1:");
            Console.Write("Length: ");
            double length1 = double.Parse(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth1 = double.Parse(Console.ReadLine());
            Box box1 = new Box(length1, breadth1);


            Console.WriteLine("Enter dimensions for Box 2:");
            Console.Write("Length: ");
            double length2 = double.Parse(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth2 = double.Parse(Console.ReadLine());
            Box box2 = new Box(length2, breadth2);


            Box box3 = Box.Add(box1, box2);


            Console.WriteLine("Box 1:");
            box1.Display();
            Console.WriteLine("Box 2:");
            box2.Display();
            Console.WriteLine("Result of addition (Box 1 + Box 2):");
            box3.Display();
            Console.ReadKey();
        }
    }
}

