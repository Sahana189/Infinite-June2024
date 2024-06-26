using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC2
{
    class Product
    {
        
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }

    class Question2

    {
        static void Main(string[] args)
        {
            Product[] products = new Product[10];


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter details for Product {i + 1}:");
                Console.Write("Product ID: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());


                products[i] = new Product { ProductId = productId, ProductName = productName, Price = price };
            }


            Array.Sort(products, (x, y) => x.Price.CompareTo(y.Price));


            Console.WriteLine("\nSorted Products based on Price:");
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Price: {product.Price}");
            }

            Console.ReadLine();
        }
    }
}
    

