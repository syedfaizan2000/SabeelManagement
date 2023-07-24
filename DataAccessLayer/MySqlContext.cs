using DataAccessLayer.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<Registration> Registration { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>()
                .HasKey(e => new { e.AreaCode, e.RegistrationNumber });

            // Optionally, you can configure other entity properties or relationships here.

            base.OnModelCreating(modelBuilder);
        }
    }
}