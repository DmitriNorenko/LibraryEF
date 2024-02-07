using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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
                    return;
                }
            }
            Console.WriteLine("Такого пользователя нет.");
        }
        public void ShowAll()
        {
            Console.WriteLine($"Id\tName\tEmail");
            foreach (var user in Users)
            {
                Console.WriteLine($"{user.Id}\t{user.Name}\t{user.Email}");
            }
        }
        public void ShowUser()
        {
            Console.WriteLine("Введите id пользователя: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var user in Users)
            {
                if (user.Id == id)
                {
                    Console.WriteLine("Пользователь найден!");
                    Console.WriteLine($"{user.Id}\t{user.Name}\t{user.Email}");
                    return;
                }
            }
            Console.WriteLine("Такого пользователя нет.");
        }
        public void UpdateUserName()
        {
            Console.WriteLine("\nВведите id пользователя для изменения: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var user in Users)
            {
                if (user.Id == id)
                {
                    Console.WriteLine("Пользователь найден!");
                    Console.WriteLine("Введите новое имя:");
                    user.Name = Console.ReadLine();
                    Console.WriteLine("Изменения сохранены!");
                    return;
                }
            }
            Console.WriteLine("Такого пользователя нет.");
        }
    }
}
