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
                userRepository.ShowAll();
                userRepository.DeleteUser();
                userRepository.ShowAll();
                userRepository.ShowUser();
                userRepository.UpdateUserName();
                userRepository.ShowUser();
                db.SaveChanges();
            }
        }
    }
}