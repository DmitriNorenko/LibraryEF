using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEF
{
    public class BookRepository
    {
        public DbSet<Book> Books { get; set; }
        public BookRepository(DbSet<Book> books)
        {
            Books = books;
        }
        public void AddBook()
        {
            Console.WriteLine("Введите название книги: ");
            string title = Console.ReadLine();
            Console.WriteLine("Введите Email пользователя: ");
            int year = Convert.ToInt32(Console.ReadLine());
            var book = new Book() { Title = title, Year = year };
            Console.WriteLine("Пользователь добавлен!");
            Books.Add(book);
        }
    }
}
