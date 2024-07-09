using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketConcession;

namespace TicketConcessionApp
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Welcome to Ticket Concession System");
            Console.WriteLine("Please enter your age:");

            if (int.TryParse(Console.ReadLine(), out int age))
            {
                TicketConcession.TicketConcession ticketConcession = new TicketConcession.TicketConcession();
                ticketConcession.CalculateConcession(age);
            }
            else
            {
                Console.WriteLine("Invalid age entered. Please enter a valid age.");
            }

            Console.ReadLine(); // To keep the console window open

        }
    }
}
