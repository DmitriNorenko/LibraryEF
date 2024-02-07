using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryEF
{
    public class UserRepository
    {
        public DbSet<User> Users { get; set; }
        public UserRepository(DbSet<User> users) 
        {
            Users = users;
        }
        public void AddUser()
        {
            Console.WriteLine("Введите имя пользователя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите Email пользователя: ");
            string email = Console.ReadLine();
            var user = new User { Name = name, Email = email };
            Console.WriteLine("Пользователь добавлен!");
            Users.Add(user);
        }
        public void DeleteUser()
        {
            Console.WriteLine("Введите id пользователя для удаления: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var user in Users) 
            {
               if(user.Id == id)
                {
                    Users.Remove(user);
                }
            }
            
        }
    }
}
