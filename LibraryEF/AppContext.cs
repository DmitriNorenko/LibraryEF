using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEF
{
    public class AppContext : DbContext
    {
       public DbSet<User> Users { get; set; }
       public DbSet<Book> Books { get; set; }
        public AppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SFAH3FP\SQLEXPRESS;
            DataBase=LibraryEF;Trusted_Connection = True; TrustServerCertificate = True");
        }
    }
}
