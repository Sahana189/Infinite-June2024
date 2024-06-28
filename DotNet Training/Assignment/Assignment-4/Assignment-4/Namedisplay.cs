using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Namedisplay
    {
        static void Main(string[] args)
        {
            string firstName = "Sahana";
            string lastName = "Navali";

            Display(firstName, lastName);
        }
        static void Display(string firstName, string lastName)
        {
            Console.WriteLine(firstName.ToUpper());
            Console.WriteLine(lastName.ToUpper());
            Console.ReadLine();
        }
    }
}

