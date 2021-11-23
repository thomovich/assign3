using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Dataacces
{
    public class ViaDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Adult> Adults { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\chris\Desktop\VIA University College\7.Semester\DNP\Rider\DNP\assign3\Library\VIA.db");
        }
    }
}
