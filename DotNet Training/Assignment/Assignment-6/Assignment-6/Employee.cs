using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    internal class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee { EmpId = 1, EmpName = "Sahana", EmpCity = "Bangalore", EmpSalary = 50000 },
            new Employee { EmpId = 2, EmpName = "Ranju", EmpCity = "Pune", EmpSalary = 48000 },
            new Employee { EmpId = 3, EmpName = "Sonu", EmpCity = "Mumbai", EmpSalary = 61000 },
            new Employee { EmpId = 4, EmpName = "Reena", EmpCity = "Kerala", EmpSalary = 40000 }
        };

            Console.WriteLine("All Employees Data:");
            DisplayEmployees(employees);

            Console.WriteLine("\nEmployees with salary greater than 45000:");
            var highSalaryEmployees = employees.Where(e => e.EmpSalary > 45000).ToList();
            DisplayEmployees(highSalaryEmployees);

            Console.WriteLine("\nEmployees from Bangalore:");
            var bangaloreEmployees = employees.Where(e => e.EmpCity == "Bangalore").ToList();
            DisplayEmployees(bangaloreEmployees);

            Console.WriteLine("\nEmployees sorted by name in ascending order:");
            var sortedEmployees = employees.OrderBy(e => e.EmpName).ToList();
            DisplayEmployees(sortedEmployees);
            Console.ReadLine();
        }

        static void DisplayEmployees(List<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
            }
        }

    }
}