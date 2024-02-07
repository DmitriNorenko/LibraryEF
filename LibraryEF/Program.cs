using System.Net.Http.Headers;

namespace LibraryEF
{
    public class Program
    {
        static void Main(string[] args)
        {
           using(var db = new AppContext())
            {
                UserRepository userRepository = new UserRepository(db.Users);
                userRepository.AddUser();
                db.SaveChanges();
                userRepository.ShowAll();
                userRepository.DeleteUser();
                db.SaveChanges();
                userRepository.ShowAll();
                userRepository.ShowUser();
                userRepository.UpdateUserName();
                db.SaveChanges();
                userRepository.ShowAll();
            }
        }
    }
}