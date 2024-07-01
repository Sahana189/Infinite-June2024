using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    interface IStudent
    {
        int StudentId { get; set; }
        string Name { get; set; }
        void ShowDetails();
    }

    public class Dayscholar : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string DaySchoolName { get; set; }

        public Dayscholar(int studentId, string name, string daySchoolName)
        {
            StudentId = studentId;
            Name = name;
            DaySchoolName = daySchoolName;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Dayscholar - Student ID: {StudentId}, Name: {Name}, Day School Name: {DaySchoolName}");
        }
    }

    public class Resident : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string HostelName { get; set; }

        public Resident(int sId, string sname, string shostelName)
        {
            StudentId = sId;
            Name = sname;
            HostelName = shostelName;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Resident - Student ID: {StudentId}, Name: {Name}, Hostel Name: {HostelName}");
        }
    }

    public class Program4
    {
        public static void Main()
        {
            Console.WriteLine("Enter details for the Dayscholar:");
            Console.Write("Student ID: ");
            int dStudentId = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string dName = Console.ReadLine();

            Console.Write("Day School Name: ");
            string dSchoolName = Console.ReadLine();

            Dayscholar ds = new Dayscholar(dStudentId, dName, dSchoolName);

            Console.WriteLine("\nEnter details for the Resident:");
            Console.Write("Student ID: ");
            int rStudentId = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string rName = Console.ReadLine();

            Console.Write("Hostel Name: ");
            string hName = Console.ReadLine();

            Resident resident = new Resident(rStudentId, rName, hName);

            Console.WriteLine("\nDetails of Dayscholar:");
            ds.ShowDetails();

            Console.WriteLine("\nDetails of Resident:");
            resident.ShowDetails();

            Console.Read();
        }
    }
}
