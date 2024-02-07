using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                if (user.Id == id)
                {
                    Console.WriteLine("Пользователь найден и удален!");
                    Users.Remove(user);
                }
                else { Console.WriteLine("Пользователя с таким id не обнаружено"); }
            }
        }
        public void ShowAll()
        {
            Console.WriteLine($"Id\tName\tEmail");
            foreach (var user in Users)
            {
                Console.WriteLine($"{user.Id}\t{user.Name}\t{user.Email}");
            }
        }
    }
}
