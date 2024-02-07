namespace LibraryEF
{
    public class Program
    {
        static void Main(string[] args)
        {
           using(var db = new AppContext())
            {
                UserRepository userRepository = new UserRepository();
                User user = userRepository.AddUser();
                db.Add(user);
                db.SaveChanges();
            }
        }
    }
}