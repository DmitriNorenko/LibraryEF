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
        public User AddUser()
        {
            Console.WriteLine("Введите имя пользователя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите Email пользователя: ");
            string email = Console.ReadLine();
            User user = new User { Name = name, Email = email };
            Console.WriteLine("Пользователь добавлен!");
            return user;
        }
        public void DeleteUser()
        {

        }
    }
}
