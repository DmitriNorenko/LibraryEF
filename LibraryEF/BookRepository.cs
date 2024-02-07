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
        public void DeleteBook()
        {
            Console.WriteLine("Введите id книги для удаления: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var book in Books)
            {
                if (book.Id == id)
                {
                    Console.WriteLine("Книга найдена и удалена!");
                    Books.Remove(book);
                    return;
                }
            }
            Console.WriteLine("Такой книги нет.");
        }
        public void ShowAllBooks()
        {
            Console.WriteLine($"Id\tTitle\tYear");
            foreach (var book in Books)
            {
                Console.WriteLine($"{book.Id}\t{book.Title}\t{book.Year}");
            }
        }
        public void ShowBook()
        {
            Console.WriteLine("Введите id книги: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var book in Books)
            {
                if (book.Id == id)
                {
                    Console.WriteLine("Книга найдена!");
                    Console.WriteLine($"{book.Id}\t{book.Title}\t{book.Year}");
                    return;
                }
            }
            Console.WriteLine("Такой книги нет.");
        }
        public void UpdateBookYear()
        {
            Console.WriteLine("\nВведите id Книги для изменения: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var book in Books)
            {
                if (book.Id == id)
                {
                    Console.WriteLine("Книга найдена!");
                    Console.WriteLine("Введите новый год:");
                    book.Year = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Изменения сохранены!");
                    return;
                }
            }
            Console.WriteLine("Такой книги нет.");
        }
    }
}
