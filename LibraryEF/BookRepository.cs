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
            Console.WriteLine("Введите год выпуска: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите автора книги: ");
            string author = Console.ReadLine();
            Console.WriteLine("Введите жанр книги: ");
            string genre = Console.ReadLine();
            Console.WriteLine("Введите Id Пользователя книги ");
            int userId = Convert.ToInt32(Console.ReadLine());
            var book = new Book()
            {
                Title = title,
                Year = year,
                Author = author,
                Genre = genre,
                UserId = userId
            };
            Console.WriteLine("Книга добавлена!");
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
            Console.WriteLine();
            var ColumnList = new List<string>()
            {
                "Id",
                "Title",
                "Year",
                "Author",
                "Genre",
                "UserId"
            };
            foreach (string column in ColumnList)
            {
                Console.Write(column + "  \t ");
            }
            Console.WriteLine();
            foreach (var book in Books)
            {
                Console.WriteLine($"{book.Id} \t{book.Title} \t{book.Year}" +
                    $" \t{book.Author} \t{book.Genre} \t{book.UserId}");
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
                    Console.WriteLine($"{book.Id}\t{book.Title}\t{book.Year}" +
                   $"\t{book.Author}\t{book.Genre}\t{book.UserId}");
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
        public void ShowGenre()
        {
            Console.WriteLine("Какой жанр вам нужен: ");
            string genre = Console.ReadLine().ToLower();
            Console.WriteLine("С какого года : ");
            int fromYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("До какого года : ");
            int toYear = Convert.ToInt32(Console.ReadLine());
            var Genre = Books.Where(u => u.Genre == genre)
                .Where(u => u.Year >= fromYear)
                .Where(u => u.Year <= toYear);
            foreach (var book in Genre)
            {
                Console.WriteLine($"{book.Id}\t{book.Title}\t{book.Year}" +
                   $"\t{book.Author}\t{book.Genre}\t{book.UserId}");
            }
        }
        public void ShowAuthor()
        {
            Console.WriteLine("Какой автор вам нужен: ");
            string author = Console.ReadLine();
            var Author = Books.Where(u => u.Author == author);

            foreach (var a in Author)
            {
                Console.WriteLine($"{a.Id}\t{a.Title}\t{a.Year}" +
                   $"\t{a.Author}\t{a.Genre}\t{a.UserId}");
            }
        }
        public void ShowGenreOnly()
        {
            Console.WriteLine("Какой жанр вам нужен: ");
            string genre = Console.ReadLine().ToLower();
            var Genre = Books.Where(u => u.Genre == genre).Count();
            Console.WriteLine(Genre);
        }
        public bool CheckBook()
        {
            Console.WriteLine("Какой нужен автор: ");
            string author = Console.ReadLine();
            Console.WriteLine("Название нужной книги: ");
            string title = Console.ReadLine();
            var Book = Books.Where(u => u.Title == title)
                .Where(u => u.Author == author);
            if (Book.Count() > 0)
            {
                Console.WriteLine("Такая книга есть");
                return true;
            }
            else
            {
                Console.WriteLine("Такой книги нет");
                return false;
            }
        }
        public bool CheckUserHaveBook()
        {
            Console.WriteLine("Название нужной книги: ");
            string title = Console.ReadLine();
            Console.WriteLine("Введите id пользователя: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var checkUserBook = Books.Where(u => u.UserId == id)
                .Where(u => u.Title == title);
            if (checkUserBook.Count() > 0)
            {
                Console.WriteLine("Книга у пользователя");
                return true;
            }
            else
            {
                Console.WriteLine("Книга у другого пользователя");
                return false;
            }
        }
        public void CountBookHaveUser()
        {
            Console.WriteLine("Введите id пользователя: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var checkcountBook = Books.Where(u => u.UserId == id).Count();
            Console.WriteLine(checkcountBook);
        }
        public void Year()
        {
            Console.WriteLine("Самая новая книга: ");
            var book = Books.OrderByDescending(u => u.Year).First();
            Console.WriteLine($"{book.Id}\t{book.Title}\t{book.Year}" +
                  $"\t{book.Author}\t{book.Genre}\t{book.UserId}");
        }
        public void SortedTitle()
        {
            var title = Books.OrderBy(u => u.Title).Select(u => u.Title);
            foreach (var item in title) Console.WriteLine(item);
        }
        public void SortedYear()
        {
            var year = Books.OrderByDescending(u => u.Year);
            foreach (var item in year)
            {
                Console.WriteLine(item.Title+"\t"+item.Year);
            }
        }
    }
}
