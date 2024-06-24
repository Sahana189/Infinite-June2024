using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Customer
    {
        private int customerId;
        private string name;
        private int age;
        private string phone;
        private string city;

        public Customer()
        {
            Console.WriteLine("Default constructor called - Customer object created with default values.");
        }

        public Customer(int customerId, string name, int age, string phone, string city)
        {
            this.customerId = customerId;
            this.name = name;
            this.age = age;
            this.phone = phone;
            this.city = city;
            Console.WriteLine("Parameterized constructor called - Customer object created with provided values.");
        }

        public void DisplayCustomer()
        {
            Console.WriteLine("\nCustomer Details:");
            Console.WriteLine($"Customer ID: {customerId}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Phone: {phone}");
            Console.WriteLine($"City: {city}");
        }

        ~Customer()
        {
            Console.WriteLine($"Destructor called - Customer object with ID {customerId} destroyed.");
        }

        public static void DisplayCustomerStatic(Customer customer)
        {
            if (customer != null)
            {
                Console.WriteLine("\nStatic Display Customer Details:");
                Console.WriteLine($"Customer ID: {customer.customerId}");
                Console.WriteLine($"Name: {customer.name}");
                Console.WriteLine($"Age: {customer.age}");
                Console.WriteLine($"Phone: {customer.phone}");
                Console.WriteLine($"City: {customer.city}");
            }
            else
            {
                Console.WriteLine("Customer object is null.");
            }
        }

        public static void Main()
        {
            Customer customer1 = new Customer();
            Customer customer2 = new Customer(1, "Sahana N", 23, "153-456-9890", "Gadag");

            customer1.DisplayCustomer();
            customer2.DisplayCustomer();

            DisplayCustomerStatic(customer1);
            DisplayCustomerStatic(customer2);

            customer1 = null;
            customer2 = null;
            GC.Collect();

            Console.ReadLine();
        }
    }
}
