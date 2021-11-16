using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Dataacces
{
    class ViaDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Adult> Adults { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = VIA.db");
        }
    }
}
