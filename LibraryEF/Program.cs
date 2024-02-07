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
            }
        }
    }
}