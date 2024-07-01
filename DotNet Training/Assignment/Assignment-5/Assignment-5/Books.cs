using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book Name: {BookName}, Author: {AuthorName}");
        }
    }

    class BookShelf
    {
        private Books[] books = new Books[5];

        public void AddBook(int index, string bookName, string authorName)
        {
            if (index < 0 || index >= books.Length)
            {
                Console.WriteLine("Invalid index. Book could not be added.");
                return;
            }

            books[index] = new Books(bookName, authorName);
        }

        public Books GetBook(int index)
        {
            if (index < 0 || index >= books.Length)
            {
                Console.WriteLine("Invalid index. Returning null.");
                return null;
            }

            return books[index];
        }
    }

    class Book_Author

    {
        static void Main(string[] args)
        {
            BookShelf bookShelf = new BookShelf();


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter details for Book {i + 1}:");
                Console.Write("Book Name: ");
                string bookName = Console.ReadLine();
                Console.Write("Author Name: ");
                string authorName = Console.ReadLine();

                bookShelf.AddBook(i, bookName, authorName);
            }


            Console.WriteLine("\nBooks on the BookShelf:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Book {i + 1}:");
                Books book = bookShelf.GetBook(i);
                if (book != null)
                    book.Display();
                Console.ReadKey();
            }
        }
    }
}
