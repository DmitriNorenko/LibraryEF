using System.Net.Http.Headers;

namespace LibraryEF
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                UserRepository userRepository = new UserRepository(db.Users);
                BookRepository bookRepository = new BookRepository(db.Books);

                // userRepository.AddUser();
                // db.SaveChanges();
                //userRepository.ShowAll();
                //userRepository.DeleteUser();
                //db.SaveChanges();
                //userRepository.ShowAll();
                //userRepository.ShowUser();
                //userRepository.UpdateUserName();
                //db.SaveChanges();
                //userRepository.ShowAll();

                //bookRepository.AddBook();
                //db.SaveChanges();
                //bookRepository.ShowAllBooks();
                //bookRepository.ShowBook();
                //bookRepository.DeleteBook();
                //db.SaveChanges();
                //bookRepository.ShowAllBooks();
                //bookRepository.UpdateBookYear();
                //db.SaveChanges();
                //bookRepository.ShowAllBooks();

                //bookRepository.ShowGenre();
                //bookRepository.ShowAuthor();
                //bookRepository.ShowGenreOnly();



            }
        }
    }
}