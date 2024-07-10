using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC4
{
    class Calculator
    {
        delegate int Operation(int a, int b);

        static void Main(string[] args)
        {
            Operation addOperation = PerformAddition;
            Operation subtractOperation = PerformSubtraction;
            Operation multiplyOperation = PerformMultiplication;

            Console.Write("Enter the first number: ");
            int firstNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"Result of Addition: {addOperation(firstNumber, secondNumber)}");
            Console.WriteLine($"Result of Subtraction: {subtractOperation(firstNumber, secondNumber)}");
            Console.WriteLine($"Result of Multiplication: {multiplyOperation(firstNumber, secondNumber)}");

            Console.ReadKey();
        }

        static int PerformAddition(int a, int b)
        {
            return a + b;
        }

        static int PerformSubtraction(int a, int b)
        {
            return a - b;
        }

        static int PerformMultiplication(int a, int b)
        {
            return a * b;
        }
    }
}
    

